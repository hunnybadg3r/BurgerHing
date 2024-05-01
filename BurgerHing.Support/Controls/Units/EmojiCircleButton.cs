using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BurgerHing.Support.Controls.Units
{
    public class EmojiCircleButton : Button
    {
        static EmojiCircleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EmojiCircleButton),
                new FrameworkPropertyMetadata(typeof(EmojiCircleButton)));
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(EmojiCircleButton));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EmojiCircleButton));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty MouseOverColorProperty =
            DependencyProperty.Register("MouseOverColor", typeof(Brush), typeof(EmojiCircleButton));

        public Brush MouseOverColor
        {
            get { return (Brush)GetValue(MouseOverColorProperty); }
            set { SetValue(MouseOverColorProperty, value); }
        }

        public static readonly DependencyProperty PressedColorProperty =
            DependencyProperty.Register("PressedColor", typeof(Brush), typeof(EmojiCircleButton));

        public Brush PressedColor
        {
            get { return (Brush)GetValue(PressedColorProperty); }
            set { SetValue(PressedColorProperty, value); }
        }
    }
}