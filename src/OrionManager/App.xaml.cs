using System;
using System.Windows;
using BAJIEPA.Tools.Helpers;
using OrionManager.Common.Interfaces;
using OrionManager.Services;
using OrionManager.ViewModel;
using OrionManager.ViewModel.Interfaces;
using OrionManager.ViewModel.ViewModels.Dialogs;
using OrionManager.Views.Backgrounds;
using OrionManager.Views.Dialogs;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Configuration;
using OrionManager.Views.Regions.Playing;
using Senticode.Wpf;
using Unity;

namespace OrionManager
{
    internal partial class App
    {
        public App() : base(ServiceLocator.Container)
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
                CreateMainWindow().Show();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);

                throw;
            }
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            ServicesInitializer.Init(Container);
            ViewModelInitializer.Init(Container);

            Container
                // Regions.
               .RegisterSingleton<HomeRegion>()
               .RegisterSingleton<ConfigurationRegion>()
               .RegisterSingleton<PlayingRegion>()
               .RegisterSingleton<PreStartRegion>()
               .RegisterSingleton<ConfigurationListRegion>()

                // Backgrounds.
               .RegisterSingleton<HomeBackground>()
               .RegisterSingleton<PreStartBackground>()
               .RegisterSingleton<ConfigurationBackground>()
               .RegisterSingleton<PlayingBackground>()
               .RegisterSingleton<ConfigurationListBackground>()

                // Dialogs.
               .RegisterType<IDialogFor<SelectRaceDialogViewModel>, SelectRaceDialog>()
               .RegisterType<IDialogFor<SelectCounselorDialogViewModel>, SelectCounselorDialog>()

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