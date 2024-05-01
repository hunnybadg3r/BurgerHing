using CommunityToolkit.Mvvm.ComponentModel;

namespace BurgerHing.Main.Local.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        public virtual void Dispose() { }
    }
}