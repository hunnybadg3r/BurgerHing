using BurgerHing.Main.Local.Messages;
using BurgerHing.Support.Local.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerHing.Main.Local.ViewModels
{
    public partial class PayStepOrderTypeViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
        public PayStepOrderTypeViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        public void CancelPayModal()
        {
            WeakReferenceMessenger.Default.Send(new ChangePayStepViewModelMessage(null));
        }

        [RelayCommand]
        public void SelectInOrOut(string value)
        {
            var nextStepViewModel = _serviceProvider.GetRequiredService<PayStepPaymentViewModel>();
            WeakReferenceMessenger.Default.Send(new ChangePayStepViewModelMessage(nextStepViewModel));

            WeakReferenceMessenger.Default.Send(new SetOrderInfoMessage((nameof(OrderInfo.OrderType), value)));
        }
    }
}