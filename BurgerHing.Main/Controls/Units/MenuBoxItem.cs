using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Main.Controls.Units;

public class MenuBoxItem : ListBoxItem
{
    static MenuBoxItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuBoxItem),
            new FrameworkPropertyMetadata(typeof(MenuBoxItem)));
    }
}
