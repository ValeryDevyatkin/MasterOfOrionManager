using System;
using System.Windows.Input;
using OrionManager.ViewModel.Interfaces;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Dialogs
{
    public abstract class DialogViewModelBase : ViewModelBase, IDisposable
    {
        protected DialogViewModelBase(IUnityContainer container) : base(container)
        {
        }

        public void Dispose()
        {
        }

        protected void CloseDialog()
        {
            Container.Resolve<IDialogHost>().CloseDialog();
        }

        #region CloseDialog command

        public ICommand CloseDialogCommand => _closeDialogCommand ??=
            new SyncCommand(ExecuteCloseDialog);

        private SyncCommand _closeDialogCommand;

        private void ExecuteCloseDialog(object parameter)
        {
            CloseDialog();
        }

        #endregion
    }
}