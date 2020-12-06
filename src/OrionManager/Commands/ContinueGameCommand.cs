using OrionManager.ViewModels.Main;
using OrionManager.Views.Regions.Playing;
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
            _container.Resolve<MainViewModel>().NavigateToRegionCommand.Execute(typeof(PlayingRegion));
        }
    }
}