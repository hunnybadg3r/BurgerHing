using System.Windows.Controls;
using System.Windows;

namespace BurgerHing.Main.Controls.Units
{
    public class PayStepLayout : ContentControl
{
    static PayStepLayout()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PayStepLayout),
            new FrameworkPropertyMetadata(typeof(PayStepLayout)));
    }
}
}
