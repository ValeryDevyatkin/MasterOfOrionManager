using System.Windows.Controls;
using OrionManager.ViewModel.Interfaces;
using OrionManager.ViewModel.ViewModels.Dialogs;

namespace OrionManager.Views.Dialogs
{
    internal class DialogBase<T> : UserControl, IDialogFor<T>
        where T : DialogViewModelBase
    {
    }
}