using System;
using System.Windows.Threading;
using OrionManager.Commands;
using OrionManager.DataModels;
using OrionManager.Interfaces;
using OrionManager.Items;
using OrionManager.Services;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;
using OrionManager.Views;
using OrionManager.Views.Backgrounds;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Configuration;
using OrionManager.Views.Regions.Playing;
using Senticode.Tools.WPF.MVVM.Extensions;
using Tools.Helpers;
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

                _container.Resolve<MainWindow>().Show();
                _container.Resolve<MainViewModel>().Init();

                LoadData();
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
                    // MainWindow
                   .RegisterType<MainViewModel>()
                   .RegisterSingleton<MainWindow>()

                    // View Models
                   .RegisterType<GameConfigurationViewModel>()
                   .RegisterType<GameDataViewModel>()
                   .RegisterType<AppDataViewModel>()

                    // Regions
                   .RegisterSingleton<StartRegion>()
                   .RegisterSingleton<ConfigurationRegion>()
                   .RegisterSingleton<PlayingRegion>()
                   .RegisterSingleton<PreStartRegion>()
                   .RegisterSingleton<ConfigurationListRegion>()

                    // Backgrounds
                   .RegisterSingleton<StartBackground>()
                   .RegisterSingleton<PreStartBackground>()
                   .RegisterSingleton<ConfigurationBackground>()
                   .RegisterSingleton<PlayingBackground>()

                    // Commands
                   .RegisterType<ExitAppCommand>()

                    // Services
                   .RegisterType<ISaveLoadService<AppDataModel>, AppDataSaveLoadService>()
                   .RegisterType<ISaveLoadService<GameDataModel>, GameDataSaveLoadService>()
                   .RegisterType<IDataStateHub<AppDataModel>, AppDataStateHub>()
                   .RegisterType<IDataStateHub<GameDataModel>, GameDataStateHub>()
                   .RegisterType<IRegionNavigationService, RegionNavigationService>()
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
            _container.Resolve<AppDataViewModel>().CopyFrom(appData);

            if (appData.IsGameStarted)
            {
                var gameData = _container.Resolve<ISaveLoadService<GameDataModel>>().Load();

                _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(gameData);
                _container.Resolve<GameDataViewModel>().CopyFrom(gameData);
            }
        }

        private void SaveData()
        {
            var appData = new AppDataModel(_container.Resolve<AppDataViewModel>());

            if (_container.Resolve<IDataStateHub<AppDataModel>>().DetectChanges(appData))
            {
                _container.Resolve<ISaveLoadService<AppDataModel>>().Save(appData);
            }

            if (appData.IsGameStarted)
            {
                var gameData = new GameDataModel(_container.Resolve<GameDataViewModel>());

                if (_container.Resolve<IDataStateHub<GameDataModel>>().DetectChanges(gameData))
                {
                    _container.Resolve<ISaveLoadService<GameDataModel>>().Save(gameData);
                }
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