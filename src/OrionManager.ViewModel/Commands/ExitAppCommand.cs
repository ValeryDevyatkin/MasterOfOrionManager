using System.Windows;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class ExitAppCommand : SyncCommandBase
    {
        private readonly IUnityContainer _container;

        public ExitAppCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            _container.Resolve<Application>().Shutdown();
        }
    }
}