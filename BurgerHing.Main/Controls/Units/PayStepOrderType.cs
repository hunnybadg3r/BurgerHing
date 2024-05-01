using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Main.Controls.Units;

public class PayStepOrderType : ContentControl
{
    static PayStepOrderType()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PayStepOrderType),
            new FrameworkPropertyMetadata(typeof(PayStepOrderType)));
    }
}
