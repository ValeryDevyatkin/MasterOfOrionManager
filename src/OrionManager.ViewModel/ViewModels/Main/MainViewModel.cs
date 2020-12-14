using OrionManager.Common.Enums;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Main
{
    public partial class MainViewModel : ViewModelBase<AppSettings, AppCommands>
    {
        public MainViewModel() : base(null)
        {
        }

        public MainViewModel(IUnityContainer container) : base(container)
        {
            Container.RegisterInstance(this);
        }

        public GameDataViewModel GameData => Container.Resolve<GameDataViewModel>();

        #region IsGameStarted: bool

        public bool IsGameStarted
        {
            get => _isGameStarted;
            set => SetProperty(ref _isGameStarted, value);
        }

        private bool _isGameStarted;

        #endregion

        #region Region: UiRegions

        public UiRegions Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        private UiRegions _region;

        #endregion
    }
}