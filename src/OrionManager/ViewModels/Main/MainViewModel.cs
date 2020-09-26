using OrionManager.Interfaces;
using Senticode.Tools.WPF.Core.Collections;
using Senticode.Tools.WPF.MVVM.Base;
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

        public AppDataViewModel AppData => Container.Resolve<AppDataViewModel>();
        public GameDataViewModel GameData => Container.Resolve<GameDataViewModel>();

        public ObservableRangeCollection<GameConfigurationViewModel> GameConfigurations { get; } =
            new ObservableRangeCollection<GameConfigurationViewModel>();

        public void Init()
        {
            InitNavigation();
        }

        #region SelectedConfiguration: GameConfigurationViewModel

        public GameConfigurationViewModel SelectedConfiguration
        {
            get => _selectedConfiguration;
            set => SetProperty(ref _selectedConfiguration, value);
        }

        private GameConfigurationViewModel _selectedConfiguration;

        #endregion

        #region CurrentConfiguration: GameConfigurationViewModel

        public GameConfigurationViewModel CurrentConfiguration
        {
            get => _currentConfiguration;
            private set => SetProperty(ref _currentConfiguration, value);
        }

        private GameConfigurationViewModel _currentConfiguration;

        #endregion
    }
}