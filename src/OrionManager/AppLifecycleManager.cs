using System;
using System.Diagnostics;
using System.Windows.Threading;
using OrionManager.Commands;
using OrionManager.ViewModels;
using OrionManager.Views;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Playing;
using Senticode.Tools.WPF.MVVM.Extensions;
using Unity;

namespace OrionManager
{
    internal static class AppLifecycleManager
    {
        private static App _app;

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
                var container = _app.Container;
                _app.DispatcherUnhandledException += OnDispatcherUnhandledException;
                container.Resolve<AppSettings>().LoadSettings();
                _app.SetMainWindow<MainWindow, MainViewModel>();
                container.Resolve<MainWindow>().Show();
                container.Resolve<MainViewModel>().Initialize();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
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
                _app.Container
                    // MainWindow
                    .RegisterType<MainViewModel>()
                    .RegisterSingleton<MainWindow>()

                    // Regions
                    .RegisterSingleton<StartRegion>()
                    .RegisterSingleton<SettingsRegion>()
                    .RegisterSingleton<PlayingRegion>()

                    // Commands
                    .RegisterType<ExitAppCommand>()
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
                //todo
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