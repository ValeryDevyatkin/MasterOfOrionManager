using OrionManager.Commands;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager
{
    internal class AppCommands : AppCommandsBase
    {
        public AppCommands(IUnityContainer container) : base(container)
        {
        }

        public ExitAppCommand ExitAppCommand => Container.Resolve<ExitAppCommand>();
        public StartGameCommand StartGameCommand => Container.Resolve<StartGameCommand>();
        public ContinueGameCommand ContinueGameCommand => Container.Resolve<ContinueGameCommand>();
        public StartNewRoundCommand StartNewRoundCommand => Container.Resolve<StartNewRoundCommand>();
        public FinishGameCommand FinishGameCommand => Container.Resolve<FinishGameCommand>();
        public NavigateToRegionCommand NavigateToRegionCommand => Container.Resolve<NavigateToRegionCommand>();
    }
}