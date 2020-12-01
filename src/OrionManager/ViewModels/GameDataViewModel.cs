using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class GameDataViewModel : ViewModelBase
    {
        public GameDataViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }
    }
}