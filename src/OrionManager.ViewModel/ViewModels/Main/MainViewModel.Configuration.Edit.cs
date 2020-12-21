using System.Windows.Input;
using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Main
{
    public partial class MainViewModel
    {
        private void ExitEditMode()
        {
            ConfigurationEditCopy = null;
            Region = UiRegions.ConfigurationList;
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
            Container.Resolve<IAppLifecycleService>().SaveConfigurationChanges();
        }

        #endregion

        #region OkEditConfiguration command

        public ICommand OkEditConfigurationCommand => _okEditConfigurationCommand ??=
                                                          new SyncCommand(ExecuteOkEditConfiguration);

        private SyncCommand _okEditConfigurationCommand;

        private void ExecuteOkEditConfiguration(object parameter)
        {
            Container.Resolve<IAppLifecycleService>().SaveConfigurationChanges();

            ExitEditMode();
        }

        #endregion

        #region CancelEditConfiguration command

        public ICommand CancelEditConfigurationCommand => _cancelEditConfigurationCommand ??=
                                                              new SyncCommand(ExecuteCancelEditConfiguration);

        private SyncCommand _cancelEditConfigurationCommand;

        private void ExecuteCancelEditConfiguration(object parameter)
        {
            ExitEditMode();
        }

        #endregion
    }
}