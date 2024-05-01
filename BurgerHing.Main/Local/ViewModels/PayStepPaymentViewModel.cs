using BurgerHing.Configuration;
using BurgerHing.Main.Local.Messages;
using BurgerHing.Support.Local.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerHing.Main.Local.ViewModels
{
    public partial class PayStepPaymentViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private List<CartItemInfo> _orderItems;
        [ObservableProperty]
        private string _displayTotalPrice;
        private decimal _totalPrice;

        public PayStepPaymentViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            OrderItems = WeakReferenceMessenger.Default.Send<RequestOrderItemsMessage>();

            _totalPrice = OrderItems.Sum(i => i.Price * i.Quantity);

            var _priceDisplaySettings = new PriceDisplaySettings();
            AppSettings.Instance.Configuration.Bind(PriceDisplaySettings.SectionName, _priceDisplaySettings);

            var format = _priceDisplaySettings.PriceStringFormat;
            var notation = _priceDisplaySettings.PriceUnitNotation;
            var unit = _priceDisplaySettings.PriceUnit;

            DisplayTotalPrice = notation == PriceUnitNotation.Prefix ? $"{unit} {_totalPrice.ToString(format)}"
                                                                     : $"{_totalPrice.ToString(format)} {unit}";
        }

        [RelayCommand]
        public void SubmitPay()
        {
            WeakReferenceMessenger.Default.Send(new SetOrderInfoMessage((nameof(OrderInfo.TotalPrice), _totalPrice)));
            WeakReferenceMessenger.Default.Send(new SetOrderInfoMessage((nameof(OrderInfo.Menus), OrderItems.ToList())));

            WeakReferenceMessenger.Default
                .Send(new ChangePayStepViewModelMessage(_serviceProvider.GetRequiredService<PayStepOrderResultViewModel>()));
        }

        [RelayCommand]
        public void CancelPayModal()
        {
            WeakReferenceMessenger.Default.Send(new ChangePayStepViewModelMessage(null));
        }
    }
}