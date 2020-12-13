using System;
using System.Windows;
using System.Windows.Threading;
using BAJIEPA.Tools.Helpers;
using OrionManager.Common.DataItems;
using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using OrionManager.Services;
using OrionManager.ViewModel;
using OrionManager.ViewModel.ViewModels.Main;
using OrionManager.Views;
using OrionManager.Views.Backgrounds;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Configuration;
using OrionManager.Views.Regions.Playing;
using Senticode.Wpf.Extensions;
using Unity;

namespace OrionManager
{
    internal partial class App
    {
        public void ExitApp()
        {
            try
            {
                Shutdown();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            DispatcherUnhandledException += OnDispatcherUnhandledException;

            base.OnStartup(args);

            try
            {
                this.SetMainWindow<MainWindow, MainViewModel>();

                Container.Resolve<IAppLifecycleService>().ExitApp = ExitApp;
                Container.Resolve<IAppLifecycleService>().LoadData();
                Container.Resolve<MainViewModel>().Init();
                Container.Resolve<MainWindow>().Show();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            try
            {
                ServicesInitializer.Instance.Init(Container);
                ViewModelInitializer.Instance.Init(Container);

                Container

                    // Regions.
                   .RegisterSingleton<MainWindow>()
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

                    //
                    ;

                InitRegionNavigation();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        protected override void OnExit(ExitEventArgs args)
        {
            base.OnExit(args);

            try
            {
                Container.Resolve<IAppLifecycleService>().SaveData();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        private void InitRegionNavigation()
        {
            Container.Resolve<IRegionNavigationService>().Init(
                new RegionNavigationInfoItem(
                    UiRegions.Start, typeof(StartRegion), typeof(StartBackground)),
                new RegionNavigationInfoItem(
                    UiRegions.PreStart, typeof(PreStartRegion), typeof(PreStartBackground)),
                new RegionNavigationInfoItem(
                    UiRegions.ConfigurationList, typeof(ConfigurationListRegion),
                    typeof(ConfigurationBackground)),
                new RegionNavigationInfoItem(
                    UiRegions.Configuration, typeof(ConfigurationRegion), typeof(ConfigurationBackground)),
                new RegionNavigationInfoItem(
                    UiRegions.Playing, typeof(PlayingRegion), typeof(PlayingBackground)));
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            this.LogCriticalException(e.Exception);
        }
    }
}