using System;
using System.Windows.Input;
using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using OrionManager.ViewModel.ExtensionMethods;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Main
{
    public partial class MainViewModel
    {
        private void SaveConfigurationChanges()
        {
            ConfigurationEditCopy.SaveTime = DateTime.Now;
            SelectedConfiguration.CopyFrom(ConfigurationEditCopy);
            Container.Resolve<IGameConfigurationService>().Save(SelectedConfiguration.ToDataModel());
        }

        #region ConfigurationEditCopy: GameConfigurationViewModel

        public GameConfigurationViewModel ConfigurationEditCopy
        {
            get => _configurationEditCopy;
            set => SetProperty(ref _configurationEditCopy, value);
        }

        private GameConfigurationViewModel _configurationEditCopy;

        #endregion

        #region ApplyEditConfiguration command

        public ICommand ApplyEditConfigurationCommand => _applyEditConfigurationCommand ??=
                                                             new SyncCommand(ExecuteApplyEditConfiguration);

        private SyncCommand _applyEditConfigurationCommand;

        private void ExecuteApplyEditConfiguration(object parameter)
        {
            if (SelectedConfiguration.HasDifference(ConfigurationEditCopy))
            {
                SaveConfigurationChanges();
            }
        }

        #endregion

        #region OkEditConfiguration command

        public ICommand OkEditConfigurationCommand => _okEditConfigurationCommand ??=
                                                          new SyncCommand(ExecuteOkEditConfiguration);

        private SyncCommand _okEditConfigurationCommand;

        private void ExecuteOkEditConfiguration(object parameter)
        {
            if (SelectedConfiguration.HasDifference(ConfigurationEditCopy))
            {
                SaveConfigurationChanges();
            }

            ConfigurationEditCopy = null;
            Region = UiRegions.ConfigurationList;
        }

        #endregion

        #region CancelEditConfiguration command

        public ICommand CancelEditConfigurationCommand => _cancelEditConfigurationCommand ??=
                                                              new SyncCommand(ExecuteCancelEditConfiguration);

        private SyncCommand _cancelEditConfigurationCommand;

        private void ExecuteCancelEditConfiguration(object parameter)
        {
            ConfigurationEditCopy = null;
            Region = UiRegions.ConfigurationList;
        }

        #endregion
    }
}