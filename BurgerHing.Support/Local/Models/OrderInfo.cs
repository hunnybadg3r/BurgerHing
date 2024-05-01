using BurgerHing.Support.Local.Enum;

namespace BurgerHing.Support.Local.Models
{
    public class OrderInfo
    {
        public int OrderNumber { get; set; }
        public string OrderType { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CartItemInfo> Menus { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
