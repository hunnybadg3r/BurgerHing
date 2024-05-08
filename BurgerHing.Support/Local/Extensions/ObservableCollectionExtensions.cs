using BurgerHing.Support.Local.Models;
using Mapster;
using System.Collections.ObjectModel;

namespace BurgerHing.Support.Local.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void IncreaseQuantity(this ObservableCollection<CartItemInfo> cart, MenuItemInfo menuItem)
        {
            var existItem = cart.FirstOrDefault(i => i.Name == menuItem.Name);

            if (existItem is not null)
            {
                existItem.Quantity++;
            }
            else
            {
                var newCartItem = menuItem.Adapt<CartItemInfo>();
                newCartItem.Quantity = 1;

                cart.Add(newCartItem);
            }
        }

        public static void DecreaseQuantity(this ObservableCollection<CartItemInfo> cart, MenuItemInfo menuItem)
        {
            var existItem = cart.FirstOrDefault(i => i.Name == menuItem.Name);

            if (existItem is not null)
            {
                if (existItem.Quantity > 1)
                {
                    existItem.Quantity--;
                }
                else
                {
                    cart.Remove(existItem);
                }
            }
        }
    }
}

