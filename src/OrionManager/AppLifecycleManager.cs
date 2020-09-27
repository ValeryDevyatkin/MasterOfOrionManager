using System;
using System.Diagnostics;
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
using Unity;

namespace OrionManager
{
    internal static class AppLifecycleManager
    {
        private static App _app;
        private static IUnityContainer Container => _app.Container;

        public static void Init(App app)
        {
            try
            {
                _app = app;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public static void OnAppStart()
        {
            try
            {
                _app.DispatcherUnhandledException += OnDispatcherUnhandledException;
                _app.SetMainWindow<MainWindow, MainViewModel>();

                InitRegionNavigation();

                Container.Resolve<MainWindow>().Show();
                Container.Resolve<MainViewModel>().Init();

                LoadData();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private static void InitRegionNavigation()
        {
            Container.Resolve<IRegionNavigationService>().Init(
                new RegionNavigationInfoItem(typeof(StartRegion), typeof(StartBackground)),
                new RegionNavigationInfoItem(typeof(PreStartRegion), typeof(PreStartBackground)),
                new RegionNavigationInfoItem(typeof(ConfigurationListRegion),
                                             typeof(ConfigurationBackground)),
                new RegionNavigationInfoItem(typeof(ConfigurationRegion), typeof(ConfigurationBackground)),
                new RegionNavigationInfoItem(typeof(PlayingRegion), typeof(PlayingBackground)));
        }

        private static void LoadData()
        {
            var appData = Container.Resolve<ISaveLoadService<AppDataModel>>().Load();
            Container.Resolve<IDataStateHub<AppDataModel>>().SaveState(appData);
            Container.Resolve<AppDataViewModel>().CopyFrom(appData);

            if (appData.IsGameStarted)
            {
                var gameData = Container.Resolve<ISaveLoadService<GameDataModel>>().Load();
                Container.Resolve<IDataStateHub<GameDataModel>>().SaveState(gameData);
                Container.Resolve<GameDataViewModel>().CopyFrom(gameData);
            }
        }

        private static void SaveData()
        {
            var appData = new AppDataModel(Container.Resolve<AppDataViewModel>());

            if (Container.Resolve<IDataStateHub<AppDataModel>>().DetectChanges(appData))
            {
                Container.Resolve<ISaveLoadService<AppDataModel>>().Save(appData);
            }

            if (appData.IsGameStarted)
            {
                var gameData = new GameDataModel(Container.Resolve<GameDataViewModel>());

                if (Container.Resolve<IDataStateHub<GameDataModel>>().DetectChanges(gameData))
                {
                    Container.Resolve<ISaveLoadService<GameDataModel>>().Save(gameData);
                }
            }
        }

        private static void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception);
        }

        public static void RegisterTypes()
        {
            try
            {
                Container
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
                Debug.WriteLine(e);
            }
        }

        public static void OnAppExit()
        {
            try
            {
                SaveData();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public static void ExitApp()
        {
            try
            {
                _app.Shutdown();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}