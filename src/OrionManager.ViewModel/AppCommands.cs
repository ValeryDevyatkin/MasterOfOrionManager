using System.Windows.Input;
using OrionManager.ViewModel.Commands;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ViewModel
{
    public static class AppCommands
    {
        private static readonly IUnityContainer Container = ServiceLocator.Container;

        public static ICommand ExitAppCommand => Container.Resolve<ExitAppCommand>();
        public static ICommand StartGameCommand => Container.Resolve<StartGameCommand>();
        public static ICommand ContinueGameCommand => Container.Resolve<ContinueGameCommand>();
        public static ICommand StartNewRoundCommand => Container.Resolve<StartNewRoundCommand>();
        public static ICommand FinishGameCommand => Container.Resolve<FinishGameCommand>();
        public static ICommand NavigateToRegionCommand => Container.Resolve<NavigateToRegionCommand>();
        public static ICommand ChoseRandomCounselorCommand => Container.Resolve<ChoseRandomCounselorCommand>();
    }
}