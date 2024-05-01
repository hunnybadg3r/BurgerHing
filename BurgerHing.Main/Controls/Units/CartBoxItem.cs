using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Main.Controls.Units;

public class CartBoxItem : ListBoxItem
{
    static CartBoxItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CartBoxItem),
            new FrameworkPropertyMetadata(typeof(CartBoxItem)));
    }
}
