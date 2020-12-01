using OrionManager.Interfaces;
using OrionManager.Views.Regions;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModels.Main
{
    internal partial class MainViewModel : ViewModelBase<AppSettings, AppCommands>, IInit
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
            NavigateToRegionCommand.Execute(typeof(StartRegion));
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