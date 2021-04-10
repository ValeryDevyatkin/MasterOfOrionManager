using System;
using System.Linq;
using System.Windows.Input;
using OrionManager.Common.Enums;
using OrionManager.Common.ExtensionMethods;
using OrionManager.Common.Interfaces;
using OrionManager.ViewModel.ExtensionMethods;
using Senticode.Wpf.Base;
using Senticode.Wpf.Collections;
using Senticode.Wpf.Interfaces;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Main
{
    public partial class MainViewModel
    {
        public IObservableRangeCollection<GameConfigurationViewModel> GameConfigurations { get; } =
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
                                                         new SyncCommand(ExecuteChoseConfiguration);

        private SyncCommand _choseConfigurationCommand;

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
                                                         new SyncCommand(ExecuteCloneConfiguration);

        private SyncCommand _cloneConfigurationCommand;

        private void ExecuteCloneConfiguration(object parameter)
        {
            if (SelectedConfiguration == null)
            {
                return;
            }

            var newConfiguration = Container.Resolve<GameConfigurationViewModel>();

            var playerPresets = SelectedConfiguration.PlayerPresets.Select(x =>
            {
                var playerPreset = Container.Resolve<PlayerPresetViewModel>();
                playerPreset.Race = newConfiguration.RaceMap[x.Race.Value];

                return playerPreset;
            });

            newConfiguration.Id = Guid.NewGuid();
            newConfiguration.SaveTime = DateTime.Now;
            newConfiguration.Name = $"{SelectedConfiguration.Name} - {newConfiguration.Id.GetHead()}";
            newConfiguration.MaxWinPoints = SelectedConfiguration.MaxWinPoints;
            newConfiguration.MaxLoyaltyPoints = SelectedConfiguration.MaxLoyaltyPoints;
            newConfiguration.PlayerPresets.ReplaceAll(playerPresets);

            Container.Resolve<IGameConfigurationService>().Save(newConfiguration.ToDataModel());
            GameConfigurations.Add(newConfiguration);
            SelectedConfiguration = newConfiguration;
        }

        #endregion

        #region AddNewConfiguration command

        public ICommand AddNewConfigurationCommand => _addNewConfigurationCommand ??=
                                                          new SyncCommand(ExecuteAddNewConfiguration);

        private SyncCommand _addNewConfigurationCommand;

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
                                                          new SyncCommand(ExecuteDeleteConfiguration);

        private SyncCommand _deleteConfigurationCommand;

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
                                                        new SyncCommand(ExecuteEditConfiguration);

        private SyncCommand _editConfigurationCommand;

        private void ExecuteEditConfiguration(object parameter)
        {
            ConfigurationEditCopy = SelectedConfiguration.Clone();
            Region = UiRegions.Configuration;
        }

        #endregion

        #region UpdateConfigSelection command

        public ICommand UpdateConfigSelectionCommand => _updateConfigSelectionCommand ??=
                                                            new SyncCommand(ExecuteUpdateConfigSelection);

        private SyncCommand _updateConfigSelectionCommand;

        private void ExecuteUpdateConfigSelection(object parameter)
        {
            SelectedConfiguration = CurrentConfiguration;
        }

        #endregion
    }
}