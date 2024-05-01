using BurgerHing.Support.Local.Models;

namespace BurgerHing.Support.Local.Services
{
    interface ICartService
    {
        void AddCartItem(CartItemInfo item);
        void SubtractCartItem(CartItemInfo item);
    }

    public class CartService : ICartService
    {
        public List<CartItemInfo> Cart { get; set; } = new();

        public void AddCartItem(CartItemInfo item)
        {
            throw new NotImplementedException();
        }

        public void SubtractCartItem(CartItemInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
