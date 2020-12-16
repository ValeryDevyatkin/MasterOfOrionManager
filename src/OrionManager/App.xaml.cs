using System;
using System.Windows;
using BAJIEPA.Tools.Helpers;
using OrionManager.Common.Interfaces;
using OrionManager.Services;
using OrionManager.ViewModel;
using OrionManager.ViewModel.ViewModels.Main;
using OrionManager.Views;
using OrionManager.Views.Backgrounds;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Configuration;
using OrionManager.Views.Regions.Playing;
using Senticode.Wpf;
using Unity;

namespace OrionManager
{
    internal partial class App
    {
        public App(IUnityContainer container) : base(container)
        {
        }

        public App() : this(ServiceLocator.Container)
        {
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            ExceptionLogHelper.LogCriticalExceptionInRelease = exceptionItem => MessageBox.Show(
                exceptionItem.Message, exceptionItem.Source, MessageBoxButton.OK, MessageBoxImage.Error);

            try
            {
                base.OnStartup(args);

                Container.Resolve<IAppLifecycleService>().OnStart();

                SetMainWindow<MainWindow, MainViewModel>().Show();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);

                throw;
            }
        }

        protected override void RegisterTypes()
        {
            ServicesInitializer.Instance.RegisterTypes(Container);
            ViewModelInitializer.Instance.RegisterTypes(Container);

            Container

                // MainWindow.
               .RegisterSingleton<MainWindow>()

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
               .RegisterSingleton<ConfigurationListBackground>()

                //
                ;
        }

        protected override void OnExit(ExitEventArgs args)
        {
            try
            {
                Container.Resolve<IAppLifecycleService>().OnExit();

                base.OnExit(args);
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }
    }
}