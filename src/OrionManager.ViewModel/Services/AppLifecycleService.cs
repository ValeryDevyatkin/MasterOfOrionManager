using OrionManager.Common.DataModels;
using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Unity;

namespace OrionManager.ViewModel.Services
{
    internal class AppLifecycleService : IAppLifecycleService
    {
        private readonly IUnityContainer _container;

        public AppLifecycleService(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        public void OnStart()
        {
            var mainViewModel = _container.Resolve<MainViewModel>();

            var appData = _container.Resolve<ISaveLoadService<AppDataModel>>().Load() ?? new AppDataModel();
            _container.Resolve<IDataStateHub<AppDataModel>>().CommitState(appData);

            var gameConfigurationViewModel = _container.Resolve<GameConfigurationViewModel>();
            gameConfigurationViewModel.SetDefaultValues();

            mainViewModel.GameConfiguration = gameConfigurationViewModel;
            mainViewModel.CopyFrom(appData);
            mainViewModel.GoToRegion(UiRegions.Home);

            if (appData.IsGameStarted)
            {
                var gameData = _container.Resolve<ISaveLoadService<GameDataModel>>().Load() ?? new GameDataModel();

                _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(gameData);
                _container.Resolve<GameDataViewModel>().CopyFrom(gameData);
            }
        }

        public void OnExit()
        {
            var appData = _container.Resolve<MainViewModel>().ToDataModel();

            if (_container.Resolve<IDataStateHub<AppDataModel>>().HasChanges(appData))
            {
                _container.Resolve<ISaveLoadService<AppDataModel>>().Save(appData);
            }

            if (appData.IsGameStarted)
            {
                var gameData = _container.Resolve<GameDataViewModel>().ToDataModel();

                if (_container.Resolve<IDataStateHub<GameDataModel>>().HasChanges(gameData))
                {
                    _container.Resolve<ISaveLoadService<GameDataModel>>().Save(gameData);
                }
            }
        }
    }
}