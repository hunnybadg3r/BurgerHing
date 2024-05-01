using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Main.Controls.Units;

public class PayStepOrderResult : ContentControl
{
    static PayStepOrderResult()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PayStepOrderResult),
            new FrameworkPropertyMetadata(typeof(PayStepOrderResult)));
    }
}
