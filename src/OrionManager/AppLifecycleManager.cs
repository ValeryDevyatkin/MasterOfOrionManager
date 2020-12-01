using System;
using System.Collections.Generic;
using System.Windows.Threading;
using BAJIEPA.Tools.Helpers;
using OrionManager.Commands;
using OrionManager.DataItems;
using OrionManager.DataModels;
using OrionManager.ExtensionMethods;
using OrionManager.Interfaces;
using OrionManager.Services;
using OrionManager.Services.SaveLoad;
using OrionManager.Services.StateHub;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;
using OrionManager.Views;
using OrionManager.Views.Backgrounds;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Configuration;
using OrionManager.Views.Regions.Playing;
using Senticode.Wpf.Extensions;
using Unity;

namespace OrionManager
{
    internal class AppLifecycleManager
    {
        private App _app;
        private IUnityContainer _container;

        public void Init(App app)
        {
            try
            {
                _app = app;
                _container = app.Container;
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        public void OnAppStart()
        {
            try
            {
                _app.DispatcherUnhandledException += OnDispatcherUnhandledException;
                _app.SetMainWindow<MainWindow, MainViewModel>();

                InitRegionNavigation();
                LoadData();

                _container.Resolve<MainViewModel>().Init();
                _container.Resolve<MainWindow>().Show();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        public void RegisterTypes()
        {
            try
            {
                _container
                    // MainWindow.
                   .RegisterType<MainViewModel>()
                   .RegisterSingleton<MainWindow>()

                    // View Models.
                   .RegisterType<GameConfigurationViewModel>()
                   .RegisterType<GameDataViewModel>()

                    // Regions.
                   .RegisterSingleton<StartRegion>()
                   .RegisterSingleton<ConfigurationRegion>()
                   .RegisterSingleton<PlayingRegion>()
                   .RegisterSingleton<PreStartRegion>()
                   .RegisterSingleton<ConfigurationListRegion>()

                    // Backgrounds.
                   .RegisterSingleton<StartBackground>()
                   .RegisterSingleton<PreStartBackground>()
                   .RegisterSingleton<ConfigurationBackground>()
                   .RegisterSingleton<PlayingBackground>()

                    // Commands.
                   .RegisterType<ExitAppCommand>()

                    // Services.
                   .RegisterType<ISaveLoadService<AppDataModel>, AppDataSaveLoadService>()
                   .RegisterType<ISaveLoadService<GameDataModel>, GameDataSaveLoadService>()
                   .RegisterType<IDataStateHub<AppDataModel>, AppDataStateHub>()
                   .RegisterType<IDataStateHub<GameDataModel>, GameDataStateHub>()
                   .RegisterType<IRegionNavigationService, RegionNavigationService>()
                   .RegisterType<IGameConfigurationService, GameConfigurationService>()
                    ;
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        public void OnAppExit()
        {
            try
            {
                SaveData();
                SaveConfigurations();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        public void ExitApp()
        {
            try
            {
                _app.Shutdown();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        private void InitRegionNavigation()
        {
            _container.Resolve<IRegionNavigationService>().Init(
                new RegionNavigationInfoItem(typeof(StartRegion), typeof(StartBackground)),
                new RegionNavigationInfoItem(typeof(PreStartRegion), typeof(PreStartBackground)),
                new RegionNavigationInfoItem(typeof(ConfigurationListRegion),
                                             typeof(ConfigurationBackground)),
                new RegionNavigationInfoItem(typeof(ConfigurationRegion), typeof(ConfigurationBackground)),
                new RegionNavigationInfoItem(typeof(PlayingRegion), typeof(PlayingBackground)));
        }

        private void LoadData()
        {
            var appData = _container.Resolve<ISaveLoadService<AppDataModel>>().Load();

            _container.Resolve<IDataStateHub<AppDataModel>>().CommitState(appData);
            _container.Resolve<MainViewModel>().CopyFrom(appData);

            if (appData.IsGameStarted)
            {
                var gameData = _container.Resolve<ISaveLoadService<GameDataModel>>().Load();

                _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(gameData);
                _container.Resolve<GameDataViewModel>().CopyFrom(gameData);
            }

            // Load configurations.

            var configurationDataModels = _container.Resolve<IGameConfigurationService>().Load();
            var configurationViewModels = new List<GameConfigurationViewModel>();
            var defaultConfigurationDataModel = _container.Resolve<IGameConfigurationService>().GetDefault();
            var defaultConfigurationViewModel = _container.Resolve<GameConfigurationViewModel>();

            defaultConfigurationViewModel.CopyFrom(defaultConfigurationDataModel);
            configurationViewModels.Add(defaultConfigurationViewModel);

            var currentConfiguration = defaultConfigurationViewModel;

            foreach (var dataModel in configurationDataModels)
            {
                var viewModel = _container.Resolve<GameConfigurationViewModel>();

                viewModel.CopyFrom(dataModel);
                configurationViewModels.Add(viewModel);

                if (appData.CurrentConfigurationId == dataModel.Id)
                {
                    currentConfiguration = viewModel;
                }
            }

            _container.Resolve<MainViewModel>().GameConfigurations.ReplaceAll(configurationViewModels);
            _container.Resolve<MainViewModel>().CurrentConfiguration = currentConfiguration;
            _container.Resolve<MainViewModel>().SelectedConfiguration = currentConfiguration;
        }

        private void SaveData()
        {
            var appData = _container.Resolve<MainViewModel>().ToDataModel();

            if (_container.Resolve<IDataStateHub<AppDataModel>>().DetectChanges(appData))
            {
                _container.Resolve<ISaveLoadService<AppDataModel>>().Save(appData);
            }

            if (appData.IsGameStarted)
            {
                var gameData = _container.Resolve<GameDataViewModel>().ToDataModel();

                if (_container.Resolve<IDataStateHub<GameDataModel>>().DetectChanges(gameData))
                {
                    _container.Resolve<ISaveLoadService<GameDataModel>>().Save(gameData);
                }
            }
        }

        private void SaveConfigurations()
        {
            foreach (var viewModel in _container.Resolve<MainViewModel>().GameConfigurations)
            {
                _container.Resolve<IGameConfigurationService>().Save(viewModel.ToDataModel());
            }
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            this.LogCriticalException(e.Exception);
        }

        #region singleton

        private AppLifecycleManager()
        {
        }

        public static AppLifecycleManager Instance { get; } = new AppLifecycleManager();

        #endregion
    }
}