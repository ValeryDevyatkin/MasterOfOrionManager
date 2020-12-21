using System;
using System.Collections.Generic;
using OrionManager.Common.DataModels;
using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.Helpers;
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

            mainViewModel.Region = UiRegions.Home;
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
            var currentConfiguration = DefaultConfigurationHelper.GetDefaultConfigurationViewModel();

            configurationViewModels.Add(currentConfiguration);

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

        public void SaveConfigurationChanges()
        {
            var mainViewModel = _container.Resolve<MainViewModel>();

            if (mainViewModel.ConfigurationEditCopy == null)
            {
                throw new NotSupportedException();
            }

            if (!mainViewModel.SelectedConfiguration.HasDifference(mainViewModel.ConfigurationEditCopy))
            {
                return;
            }

            mainViewModel.SelectedConfiguration.CopyFrom(mainViewModel.ConfigurationEditCopy);
            mainViewModel.ConfigurationEditCopy.SaveTime = DateTime.Now;
            mainViewModel.ConfigurationEditCopy.Name = mainViewModel.SelectedConfiguration.Name;

            _container.Resolve<IGameConfigurationService>().Save(mainViewModel.SelectedConfiguration.ToDataModel());
        }
    }
}