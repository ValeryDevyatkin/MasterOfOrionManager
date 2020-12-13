using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using OrionManager.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.Commands
{
    public class NavigateToRegionCommand : CommandBase
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

            var navigationItem = _container.Resolve<IRegionNavigationService>().NavigateToRegion(region);
            var mainViewModel = _container.Resolve<MainViewModel>();

            mainViewModel.CurrentRegion = navigationItem.Region;
            mainViewModel.CurrentRegionBackground = navigationItem.RegionBackground;
        }
    }
}