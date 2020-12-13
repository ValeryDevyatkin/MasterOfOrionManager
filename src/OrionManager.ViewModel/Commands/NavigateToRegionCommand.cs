using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class NavigateToRegionCommand : CommandBase
    {
        private readonly IUnityContainer _container;

        public NavigateToRegionCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            if (!(parameter is UiRegions region))
            {
                return;
            }

            _container.Resolve<IAppLifecycleService>().NavigateToRegion(region);
        }
    }
}