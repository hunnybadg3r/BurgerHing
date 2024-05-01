using BurgerHing.Main.Local.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerHing.Main.Local.ViewModels
{
    public partial class PayStepLayoutViewModel : ViewModelBase, IRecipient<ChangePayStepViewModelMessage>
    {
        private readonly IServiceProvider _serviceProvider;
        [ObservableProperty]
        private ViewModelBase _payStepViewModel;

        [ObservableProperty]
        private int _step;

        public PayStepLayoutViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            PayStepViewModel = serviceProvider.GetRequiredService<PayStepOrderTypeViewModel>();

            WeakReferenceMessenger.Default.Register(this);
        }

        public void Receive(ChangePayStepViewModelMessage message)
        {
            PayStepViewModel = message.Value;
        }
    }
}
