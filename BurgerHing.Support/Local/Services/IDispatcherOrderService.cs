using BurgerHing.Support.Local.Models;

namespace BurgerHing.Support.Local.Services
{
    public interface IDispatcherOrderService
    {
        public bool DispatcherOrder(OrderInfo orderInfo);
    }
}
