using BurgerHing.Main.Local.Messages;
using BurgerHing.Support.Local.Enum;
using BurgerHing.Support.Local.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Threading;

namespace BurgerHing.Main.Local.ViewModels
{
    public partial class PayStepOrderResultViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _displayOrderNumber;

        private DispatcherTimer _timer;

        public PayStepOrderResultViewModel()
        {
            var orderCount = WeakReferenceMessenger.Default.Send(new RequestOrderNumberMessage());
            DisplayOrderNumber = orderCount.Response.ToString();

            // Move to the initial screen after 15 seconds 
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(15);
            _timer.Tick += (sender, e) =>
            {
                CloseAndReset();
            };
            _timer.Start();
        }

        ~PayStepOrderResultViewModel()
        {
            _timer?.Stop();
            _timer = null;
        }

        [RelayCommand]
        public void CloseAndReset()
        {
            WeakReferenceMessenger.Default.Send(new SetOrderInfoMessage((nameof(OrderInfo.OrderStatus), OrderStatus.Completed)));
            WeakReferenceMessenger.Default.Send(new ChangePayStepViewModelMessage(null));

            _timer.Stop();
            _timer = null;
        }
    }
}