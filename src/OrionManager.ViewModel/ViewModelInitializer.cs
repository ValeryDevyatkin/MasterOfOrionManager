using OrionManager.Common.Interfaces;
using OrionManager.ViewModel.Commands;
using OrionManager.ViewModel.Services;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Unity;

namespace OrionManager.ViewModel
{
    public class ViewModelInitializer : IModuleInitializer
    {
        public void Init(IUnityContainer container)
        {
            container

                // Commands.
               .RegisterType<ExitAppCommand>()
               .RegisterType<StartGameCommand>()
               .RegisterType<FinishGameCommand>()
               .RegisterType<NavigateToRegionCommand>()

                // Services.
               .RegisterType<IAppLifecycleService, AppLifecycleService>()

                // View Models.
               .RegisterType<MainViewModel>()
               .RegisterType<GameConfigurationViewModel>()
               .RegisterType<GameDataViewModel>()

                //
                ;
        }

        #region singleton

        private ViewModelInitializer()
        {
        }

        public static ViewModelInitializer Instance { get; } = new ViewModelInitializer();

        #endregion
    }
}