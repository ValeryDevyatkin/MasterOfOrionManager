using System;
using System.Diagnostics;
using System.Windows.Threading;
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
        public static void OnStart(App app)
        {
            try
            {
                var container = app.Container;
                app.DispatcherUnhandledException += OnDispatcherUnhandledException;
                container.Resolve<AppSettings>().LoadSettings();
                app.SetMainWindow<MainWindow, MainViewModel>();
                container.Resolve<MainWindow>().Show();
                container.Resolve<MainViewModel>().Initialize();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        private static void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Debug.WriteLine($"DISPATCHER UNHANDLED EXCEPTION: {e.Exception}");
        }

        public static void RegisterTypes(App app)
        {
            app.Container
                // MainWindow
                .RegisterType<MainViewModel>()
                .RegisterSingleton<MainWindow>()

                // Regions
                .RegisterSingleton<StartRegion>()
                .RegisterSingleton<SettingsRegion>()
                .RegisterSingleton<PlayingRegion>()
                ;
        }

        public static void OnExit(App app)
        {
            //todo
        }
    }
}