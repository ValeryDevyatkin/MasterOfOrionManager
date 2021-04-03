using OrionManager.ViewModel.ViewModels.Dialogs;

namespace OrionManager.ViewModel.Interfaces
{
    public interface IDialogHost
    {
        public void ShowDialog<T>(T viewModel) where T : DialogViewModelBase;
        public void ShowDialog<T>() where T : DialogViewModelBase;
        public void CloseDialog();
    }
}