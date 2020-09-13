using Senticode.Tools.WPF.MVVM.Base;
using Unity;

namespace OrionManager.ViewModels.Main
{
    internal partial class MainViewModel : ViewModelBase<AppSettings, AppCommands>
    {
        public MainViewModel() : base(null)
        {
        }

        public MainViewModel(IUnityContainer container) : base(container)
        {
            Container.RegisterInstance(this);
        }

        public void Initialize()
        {
            InitNavigation();
        }
    }
}