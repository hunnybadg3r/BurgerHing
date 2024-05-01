using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Main.Controls.Units;

public class MenuBox : ListBox
{
    static MenuBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuBox),
            new FrameworkPropertyMetadata(typeof(MenuBox)));
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new MenuBoxItem();
    }
}
