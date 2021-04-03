using OrionManager.Common.Interfaces;
using OrionManager.ViewModel.Commands;
using OrionManager.ViewModel.Services;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Dialogs;
using OrionManager.ViewModel.ViewModels.Main;
using Unity;

namespace OrionManager.ViewModel
{
    public class ViewModelInitializer : IModuleInitializer
    {
        public void RegisterTypes(IUnityContainer container)
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
               .RegisterType<MainViewModel>()
               .RegisterType<GameConfigurationViewModel>()
               .RegisterType<GameDataViewModel>()
               .RegisterType<SelectCounselorDialogViewModel>()
               .RegisterType<SelectRaceDialogViewModel>()

                //
                ;
        }

        #region singleton

        private ViewModelInitializer()
        {
        }

        private static ViewModelInitializer _instance;

        public static ViewModelInitializer Instance => _instance ??= new ViewModelInitializer();

        #endregion
    }
}