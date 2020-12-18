using System.Windows.Input;
using OrionManager.ViewModel.Commands;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel
{
    public class AppCommands : AppCommandsBase
    {
        public AppCommands(IUnityContainer container) : base(container)
        {
        }

        public ICommand ExitAppCommand => Container.Resolve<ExitAppCommand>();
        public ICommand StartGameCommand => Container.Resolve<StartGameCommand>();
        public ICommand ContinueGameCommand => Container.Resolve<ContinueGameCommand>();
        public ICommand StartNewRoundCommand => Container.Resolve<StartNewRoundCommand>();
        public ICommand FinishGameCommand => Container.Resolve<FinishGameCommand>();
        public ICommand NavigateToRegionCommand => Container.Resolve<NavigateToRegionCommand>();
        public ICommand ChoseRandomCounselorCommand => Container.Resolve<ChoseRandomCounselorCommand>();
    }
}