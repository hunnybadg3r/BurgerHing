using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BurgerHing.Main.Local.Messages
{
    public class SetOrderInfoMessage : ValueChangedMessage<(string key, object value)>
    {
        public SetOrderInfoMessage((string key, object value) tuple) : base(tuple)
        {
        }
    }
}
