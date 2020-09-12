using System.Windows.Controls;
using OrionManager.Views.Regions;
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
            Container.RegisterInstance(this);
        }

        public void Initialize()
        {
            CurrentRegion = Container.Resolve<StartRegion>();
        }

        #region CurrentRegion: UserControl

        public UserControl CurrentRegion
        {
            get => _currentRegion;
            private set => SetProperty(ref _currentRegion, value);
        }

        private UserControl _currentRegion;

        #endregion
    }
}