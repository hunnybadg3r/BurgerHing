using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Main.Controls.Units;

public class PayStepPayment : ContentControl
{
    static PayStepPayment()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PayStepPayment),
            new FrameworkPropertyMetadata(typeof(PayStepPayment)));
    }
}
