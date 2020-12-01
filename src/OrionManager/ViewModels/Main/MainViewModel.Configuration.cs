using System;
using System.Windows.Input;
using OrionManager.ExtensionMethods;
using Senticode.Wpf.Base;
using Senticode.Wpf.Collections;
using Unity;

namespace OrionManager.ViewModels.Main
{
    internal partial class MainViewModel
    {
        public ObservableRangeCollection<GameConfigurationViewModel> GameConfigurations { get; } =
            new ObservableRangeCollection<GameConfigurationViewModel>();

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
            set => SetProperty(ref _currentConfiguration, value,
                               OnCurrentConfigurationChanged,
                               OnCurrentConfigurationChanging);
        }

        private void OnCurrentConfigurationChanging()
        {
            if (CurrentConfiguration != null)
            {
                CurrentConfiguration.IsChosen = false;
            }
        }

        private void OnCurrentConfigurationChanged()
        {
            if (CurrentConfiguration != null)
            {
                CurrentConfiguration.IsChosen = true;
            }
        }

        private GameConfigurationViewModel _currentConfiguration;

        #endregion

        #region ChoseConfiguration command

        public ICommand ChoseConfigurationCommand => _choseConfigurationCommand ??=
                                                         new Command(ExecuteChoseConfiguration);

        private Command _choseConfigurationCommand;

        private void ExecuteChoseConfiguration(object parameter)
        {
            if (SelectedConfiguration == null)
            {
                return;
            }

            CurrentConfiguration = SelectedConfiguration;
        }

        #endregion

        #region CloneConfiguration command

        public ICommand CloneConfigurationCommand => _cloneConfigurationCommand ??=
                                                         new Command(ExecuteCloneConfiguration);

        private Command _cloneConfigurationCommand;

        private void ExecuteCloneConfiguration(object parameter)
        {
            if (SelectedConfiguration == null)
            {
                return;
            }

            var configuration = Container.Resolve<GameConfigurationViewModel>();

            configuration.Id = Guid.NewGuid();
            configuration.SaveTime = DateTime.Now;
            configuration.Name = $"{SelectedConfiguration.Name} - {configuration.Id.GetHead()}";

            GameConfigurations.Add(configuration);
            SelectedConfiguration = configuration;
        }

        #endregion

        #region AddNewConfiguration command

        public ICommand AddNewConfigurationCommand => _addNewConfigurationCommand ??=
                                                          new Command(ExecuteAddNewConfiguration);

        private Command _addNewConfigurationCommand;

        private void ExecuteAddNewConfiguration(object parameter)
        {
            if (SelectedConfiguration == null)
            {
                return;
            }

            var configuration = Container.Resolve<GameConfigurationViewModel>();

            configuration.Id = Guid.NewGuid();
            configuration.SaveTime = DateTime.Now;
            configuration.Name = configuration.Id.GetHead();

            GameConfigurations.Add(configuration);
            SelectedConfiguration = configuration;
        }

        #endregion
    }
}