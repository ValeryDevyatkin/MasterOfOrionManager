using System.Windows;
using OrionManager.ViewModels;
using OrionManager.Views;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Playing;
using Senticode.Tools.WPF.MVVM.Extensions;
using Unity;

namespace OrionManager
{
    internal partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.SetMainWindow<MainWindow, MainViewModel>();
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            Container
                // MainWindow
                .RegisterType<MainViewModel>()
                .RegisterSingleton<MainWindow>()

                // Regions
                .RegisterSingleton<StartRegion>()
                .RegisterSingleton<SettingsRegion>()
                .RegisterSingleton<PlayingRegion>()
                ;
        }
    }
}