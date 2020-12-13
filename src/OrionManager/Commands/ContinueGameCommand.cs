using OrionManager.Common.Enums;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.Commands
{
    public class ContinueGameCommand : CommandBase
    {
        private readonly IUnityContainer _container;

        public ContinueGameCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            _container.Resolve<NavigateToRegionCommand>().Execute(UiRegions.Playing);
        }
    }
}