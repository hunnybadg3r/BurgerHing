using BurgerHing.Support.Local.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BurgerHing.Main.Local.Messages
{
    public class RequestOrderItemsMessage : RequestMessage<List<CartItemInfo>>
    {
    }
}
