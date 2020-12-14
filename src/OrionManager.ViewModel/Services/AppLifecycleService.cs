using System;
using System.Collections.Generic;
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

        public Action ExitApp { get; set; }

        public void OnStart()
        {
            var mainViewModel = _container.Resolve<MainViewModel>();
            var appData = _container.Resolve<ISaveLoadService<AppDataModel>>().Load() ?? new AppDataModel();

            _container.Resolve<IDataStateHub<AppDataModel>>().CommitState(appData);

            mainViewModel.Region = UiRegions.Start;
            mainViewModel.CopyFrom(appData);

            if (appData.IsGameStarted)
            {
                var gameData = _container.Resolve<ISaveLoadService<GameDataModel>>().Load() ?? new GameDataModel();

                _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(gameData);
                _container.Resolve<GameDataViewModel>().CopyFrom(gameData);
            }

            // Load configurations.

            var configurationDataModels = _container.Resolve<IGameConfigurationService>().Load();
            var configurationViewModels = new List<GameConfigurationViewModel>();

            var defaultConfigurationViewModel =
                _container.Resolve<IGameConfigurationService>().GetDefault().ToViewModel();

            defaultConfigurationViewModel.IsDefault = true;

            var currentConfiguration = defaultConfigurationViewModel;

            configurationViewModels.Add(defaultConfigurationViewModel);

            foreach (var dataModel in configurationDataModels)
            {
                var viewModel = dataModel.ToViewModel();

                configurationViewModels.Add(viewModel);

                if (appData.CurrentConfigurationId == dataModel.Id)
                {
                    currentConfiguration = viewModel;
                }
            }

            mainViewModel.GameConfigurations.ReplaceAll(configurationViewModels);
            mainViewModel.CurrentConfiguration = currentConfiguration;
            mainViewModel.SelectedConfiguration = currentConfiguration;
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