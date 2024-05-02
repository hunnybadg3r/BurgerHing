using BurgerHing.Support.Local.Models;

namespace BurgerHing.Support.Local.Services
{
    public interface IMenuService
    {
        List<MenuItemInfo> GetMenuItems(string category);
    }
}
