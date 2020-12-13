using OrionManager.Common.Enums;
using OrionManager.ExtensionMethods;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.Commands
{
    public class FinishGameCommand : CommandBase
    {
        private readonly IUnityContainer _container;

        public FinishGameCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            _container.Resolve<MainViewModel>().IsGameStarted = false;
            _container.Resolve<GameDataViewModel>().Reset();
            _container.Resolve<NavigateToRegionCommand>().Execute(UiRegions.Start);
        }
    }
}