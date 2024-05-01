namespace BurgerHing.Support.Local.Models
{
    public class CartItemInfo : MenuItemInfo
    {
        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }
    }
}
