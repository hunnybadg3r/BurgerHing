using BurgerHing.Main.Local.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BurgerHing.Main.Local.Messages
{
    public class ChangePayStepViewModelMessage : ValueChangedMessage<ViewModelBase>
    {
        public ChangePayStepViewModelMessage(ViewModelBase value) : base(value)
        {
        }
    }
}
