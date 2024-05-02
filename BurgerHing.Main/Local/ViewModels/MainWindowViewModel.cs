using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using BurgerHing.Main.Local.Messages;
using BurgerHing.Support.Local.Enum;
using BurgerHing.Support.Local.Extensions;
using BurgerHing.Support.Local.Models;
using BurgerHing.Support.Local.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using Microsoft.Extensions.DependencyInjection;

namespace BurgerHing.Main.Local.ViewModels;

public partial class MainWindowViewModel : 
    ViewModelBase, 
    IRecipient<SetOrderInfoMessage>, 
    IRecipient<RequestOrderItemsMessage>, 
    IRecipient<ChangePayStepViewModelMessage>,
    IRecipient<RequestOrderNumberMessage>
{
    private readonly IMenuService _menuService;
    private readonly IDispatcherOrderService _dispatcherOrderService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ViewModelBase _modalViewModel; 
    public bool IsModalOpen => ModalViewModel is not null;

    [ObservableProperty]
    private decimal _totalPrice;
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(OpenPayModalCommand))]
    [NotifyCanExecuteChangedFor(nameof(ClearCartCommand))]
    private decimal _totalQuantity;
    
    [ObservableProperty]
    private bool _resetScrollViewer;

    public ObservableCollection<MenuItemInfo> DisplayMenus { get; set; } = [];
    public ObservableCollection<CartItemInfo> CartItems { get; set; } = [];
    public OrderInfo OrderInfo { get; set; } = new();
    public int OrderCount = 1;

    public MainWindowViewModel(
        IMenuService menuService,
        IDispatcherOrderService dispatcherOrderService,
        IServiceProvider serviceProvider)
    {
        _menuService = menuService;
        _dispatcherOrderService = dispatcherOrderService;

        SelectMenuCategory("Burger");
        CartItems.CollectionChanged += CartItems_CollectionChanged;
        _serviceProvider = serviceProvider;

        WeakReferenceMessenger.Default.Register<SetOrderInfoMessage>(this);
        WeakReferenceMessenger.Default.Register<RequestOrderItemsMessage>(this);
        WeakReferenceMessenger.Default.Register<RequestOrderNumberMessage>(this);
        WeakReferenceMessenger.Default.Register<ChangePayStepViewModelMessage>(this);
    }

    public override void Dispose()
    {
        CartItems.CollectionChanged -= CartItems_CollectionChanged;
        base.Dispose();
    }

    private bool CanPay()
    {
        return TotalQuantity is not 0;
    }
    
    private void CartItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            foreach (var newItem in e.NewItems.OfType<CartItemInfo>())
            {
                newItem.PropertyChanged += CartItem_PropertyChanged;
            }
        }
        else if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            foreach (var oldItem in e.OldItems.OfType<CartItemInfo>())
            {
                oldItem.PropertyChanged -= CartItem_PropertyChanged;
            }
        }

        UpdateTotals();
    }

    private void UpdateTotals()
    {
        TotalPrice = GetTotalPrice();
        TotalQuantity = GetTotalQuantity();
    }

    private void CartItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        UpdateTotals();
    }

    private decimal GetTotalPrice()
    {
        return CartItems.Sum(item => item.Price * item.Quantity);
    }

    private decimal GetTotalQuantity()
    {
        return CartItems.Sum(item => item.Quantity);
    }

    [RelayCommand(CanExecute = nameof(CanPay))]
    public void ClearCart()
    {
        CartItems.Clear();
    }

    [RelayCommand]
    public void SelectMenuCategory(string category)
    {
        DisplayMenus.Clear();

        _menuService.GetMenuItems(category).ForEach(m => DisplayMenus.Add(m));
    }

    [RelayCommand]
    public void IncreaseCartItem(MenuItemInfo menuItem)
    {
        CartItems.IncreaseQuantity(menuItem);
    }

    [RelayCommand]
    public void DecreaseCartItem(CartItemInfo item)
    {
        CartItems.DecreaseQuantity(item);
    }

    [RelayCommand(CanExecute = nameof(CanPay))]
    public void OpenPayModal()
    {
        ModalViewModel = _serviceProvider.GetRequiredService<PayStepLayoutViewModel>();
        OnPropertyChanged(nameof(IsModalOpen));
    }

    public void Receive(SetOrderInfoMessage message)
    {
        var propertyInfo = OrderInfo.GetType().GetProperty(message.Value.key);
        var convertedValue = Convert.ChangeType(message.Value.value, propertyInfo.PropertyType);
        
        propertyInfo.SetValue(OrderInfo, convertedValue, null);

        if (message.Value.key == nameof(OrderInfo.OrderStatus) && convertedValue is OrderStatus orderStatus)
        {
            if (orderStatus == OrderStatus.Completed)
            {
                OrderInfo.OrderDate = DateTime.UtcNow;
                _dispatcherOrderService.DispatcherOrder(OrderInfo);

                CartItems.Clear();
                DisplayMenus.Clear();
                OrderCount++;
                SelectMenuCategory("Burger");
            }
        }
    }

    public void Receive(RequestOrderItemsMessage message)
    {
        message.Reply(CartItems.ToList());
    }

    public void Receive(ChangePayStepViewModelMessage message)
    {
        if (message.Value is null)
        {
            ModalViewModel = null;
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }

    public void Receive(RequestOrderNumberMessage message)
    {
        message.Reply(OrderCount);
    }
}
