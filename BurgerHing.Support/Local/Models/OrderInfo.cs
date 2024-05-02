using BurgerHing.Support.Local.Enum;

namespace BurgerHing.Support.Local.Models
{
    public class OrderInfo
    {
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string OrderType { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<CartItemInfo> Menus { get; set; }
    }
}
