using System.Windows;
using System.Windows.Controls;

namespace BurgerHing.Main.Controls.Units
{
    public class MenuCategoryButton : RadioButton
    {
        static MenuCategoryButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuCategoryButton),
                new FrameworkPropertyMetadata(typeof(MenuCategoryButton)));
        }

        public static readonly DependencyProperty EmojiTextProperty = 
            DependencyProperty.Register("EmojiText", typeof(string), typeof(MenuCategoryButton));

        public string EmojiText
        {
            get { return (string)GetValue(EmojiTextProperty); }
            set { SetValue(EmojiTextProperty, value); }
        }
    }
}
