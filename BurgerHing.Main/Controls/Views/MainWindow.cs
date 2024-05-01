using BurgerHing.Main.Local.ViewModels;
using System.Windows;

namespace BurgerHing.Main.Controls.Views
{
    public class MainWindow : Window
    {
        static MainWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindow),
                new FrameworkPropertyMetadata(typeof(MainWindow)));
        }

        public MainWindow(MainWindowViewModel vm)
        {
            DataContext = vm;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MinWidth = 1366;
            MinHeight = 1024;
        }
    }
}
