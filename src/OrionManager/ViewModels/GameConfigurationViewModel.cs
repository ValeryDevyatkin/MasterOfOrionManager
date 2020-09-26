using Senticode.Tools.WPF.MVVM.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class GameConfigurationViewModel : ViewModelBase
    {
        public GameConfigurationViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }
    }
}