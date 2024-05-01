using BurgerHing.Support.Local.Extensions;
using BurgerHing.Support.Local.Models;
using BurgerHing.Support.Local.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BurgerHing.Menu.Local.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        private readonly IMenuService _menuService;

        public MenuViewModel(IMenuService menuService)
        {
            _menuService = menuService;

            //DisplayMenus.Clear();
            _menuService.GetMainMenuItems().ForEach(m => DisplayMenus.Add(m));
        }

        public ObservableCollection<MenuItemInfo> DisplayMenus { get; set; } = new();

        public ObservableCollection<CartItemInfo> CartItems { get; set; } = new();
        public decimal TotalPrice => CartItems.Sum(item => item.Price * item.Quantity);

        // Cart service commands
        [RelayCommand]
        public void AddCart(CartItemInfo item)
        {
            CartItems.AddQuantity(item);
        }

        [RelayCommand]
        public void SubCart(CartItemInfo item)
        {
            CartItems.SubQuantity(item);
        }
    }
}
