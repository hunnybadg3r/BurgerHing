using System.Runtime.Serialization;

namespace BurgerHing.Support.Local.Enum
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,   
        
        [EnumMember(Value = "Completed")]
        Completed,
    }
}