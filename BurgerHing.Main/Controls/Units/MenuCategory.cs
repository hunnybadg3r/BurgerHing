using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Main.Controls.Units
{
    public class MenuCategory : ContentControl
    {
        static MenuCategory()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuCategory),
                new FrameworkPropertyMetadata(typeof(MenuCategory)));
        }
    }
}
