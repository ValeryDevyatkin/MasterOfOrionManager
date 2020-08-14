using Senticode.Tools.WPF.MVVM.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class MainViewModel : ViewModelBase<AppSettings, AppCommands>
    {
        public MainViewModel() : base(null)
        {
        }

        public MainViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }
    }
}