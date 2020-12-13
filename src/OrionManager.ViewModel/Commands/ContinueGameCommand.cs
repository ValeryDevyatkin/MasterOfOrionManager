using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class ContinueGameCommand : CommandBase
    {
        private readonly IUnityContainer _container;

        public ContinueGameCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            _container.Resolve<IAppLifecycleService>().NavigateToRegion(UiRegions.Playing);
        }
    }
}