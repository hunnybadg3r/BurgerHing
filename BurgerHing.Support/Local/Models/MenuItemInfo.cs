using CommunityToolkit.Mvvm.ComponentModel;

namespace BurgerHing.Support.Local.Models
{
    public class MenuItemInfo : ObservableObject
    {
        public int DisplaySequence { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
