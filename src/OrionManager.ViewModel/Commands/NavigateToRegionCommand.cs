using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class NavigateToRegionCommand : SyncCommandBase
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

            _container.Resolve<MainViewModel>().GoToRegion(region);
        }
    }
}