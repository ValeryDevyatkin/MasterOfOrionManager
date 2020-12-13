using System;
using System.Windows.Input;
using OrionManager.Common.Enums;
using OrionManager.Common.ExtensionMethods;
using OrionManager.Common.Interfaces;
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

            var newConfiguration = Container.Resolve<GameConfigurationViewModel>();

            newConfiguration.Id = Guid.NewGuid();
            newConfiguration.SaveTime = DateTime.Now;
            newConfiguration.Name = $"{SelectedConfiguration.Name} - {newConfiguration.Id.GetHead()}";

            Container.Resolve<IGameConfigurationService>().Save(newConfiguration.ToDataModel());
            GameConfigurations.Add(newConfiguration);
            SelectedConfiguration = newConfiguration;
        }

        #endregion

        #region AddNewConfiguration command

        public ICommand AddNewConfigurationCommand => _addNewConfigurationCommand ??=
                                                          new Command(ExecuteAddNewConfiguration);

        private Command _addNewConfigurationCommand;

        private void ExecuteAddNewConfiguration(object parameter)
        {
            var newConfiguration = Container.Resolve<GameConfigurationViewModel>();

            newConfiguration.Id = Guid.NewGuid();
            newConfiguration.SaveTime = DateTime.Now;
            newConfiguration.Name = newConfiguration.Id.GetHead();

            Container.Resolve<IGameConfigurationService>().Save(newConfiguration.ToDataModel());
            GameConfigurations.Add(newConfiguration);
            SelectedConfiguration = newConfiguration;
        }

        #endregion

        #region DeleteConfiguration command

        public ICommand DeleteConfigurationCommand => _deleteConfigurationCommand ??=
                                                          new Command(ExecuteDeleteConfiguration);

        private Command _deleteConfigurationCommand;

        private void ExecuteDeleteConfiguration(object parameter)
        {
            if (SelectedConfiguration == null)
            {
                return;
            }

            Container.Resolve<IGameConfigurationService>().Delete(SelectedConfiguration.Id);
            GameConfigurations.Remove(SelectedConfiguration);
        }

        #endregion

        #region EditConfiguration command

        public ICommand EditConfigurationCommand => _editConfigurationCommand ??=
                                                        new Command(ExecuteEditConfiguration);

        private Command _editConfigurationCommand;

        private void ExecuteEditConfiguration(object parameter)
        {
            ConfigurationEditCopy = SelectedConfiguration.Clone();
            AppCommands.NavigateToRegionCommand.Execute(UiRegions.Configuration);
        }

        #endregion
    }
}