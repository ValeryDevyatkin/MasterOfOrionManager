using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Main
{
    public partial class MainViewModel : ViewModelBase<AppSettings, AppCommands>, IInit
    {
        public MainViewModel() : base(null)
        {
        }

        public MainViewModel(IUnityContainer container) : base(container)
        {
            Container.RegisterInstance(this);
        }

        public GameDataViewModel GameData => Container.Resolve<GameDataViewModel>();

        public void Init()
        {
            AppCommands.NavigateToRegionCommand.Execute(UiRegions.Start);
        }

        #region IsGameStarted: bool

        public bool IsGameStarted
        {
            get => _isGameStarted;
            set => SetProperty(ref _isGameStarted, value);
        }

        private bool _isGameStarted;

        #endregion
    }
}