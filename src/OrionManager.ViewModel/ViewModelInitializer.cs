using OrionManager.Common.Interfaces;
using OrionManager.ViewModel.Commands;
using OrionManager.ViewModel.Services;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Dialogs;
using Unity;

namespace OrionManager.ViewModel
{
    public static class ViewModelInitializer
    {
        public static void Init(IUnityContainer container)
        {
            container

                // Commands.
               .RegisterType<ExitAppCommand>()
               .RegisterType<StartGameCommand>()
               .RegisterType<FinishGameCommand>()
               .RegisterType<NavigateToRegionCommand>()
               .RegisterType<ChoseRandomCounselorCommand>()

                // Services.
               .RegisterType<IAppLifecycleService, AppLifecycleService>()

                // View Models.
               .RegisterType<GameConfigurationViewModel>()
               .RegisterType<GameDataViewModel>()
               .RegisterType<SelectCounselorDialogViewModel>()
               .RegisterType<SelectRaceDialogViewModel>()
               .RegisterType<FinishGameDialogViewModel>()

                //
                ;
        }
    }
}