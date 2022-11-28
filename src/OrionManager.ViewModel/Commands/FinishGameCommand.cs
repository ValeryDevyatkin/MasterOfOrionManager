using OrionManager.ViewModel.Interfaces;
using OrionManager.ViewModel.ViewModels.Dialogs;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class FinishGameCommand : SyncCommandBase
    {
        private readonly IUnityContainer _container;

        public FinishGameCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            var vm = _container.Resolve<FinishGameDialogViewModel>();
            _container.Resolve<IDialogHost>().ShowDialog(vm);
        }
    }
}