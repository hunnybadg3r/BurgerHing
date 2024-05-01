using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Cart.Controls.Units;

public class CartBox : ListBox
{
    static CartBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CartBox),
            new FrameworkPropertyMetadata(typeof(CartBox)));
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new CartBoxItem();
    }
}
