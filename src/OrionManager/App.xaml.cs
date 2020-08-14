using System.Windows;
using OrionManager.ViewModels;
using OrionManager.Views;
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
                .RegisterType<MainViewModel>()
                .RegisterSingleton<MainWindow>()
                ;
        }
    }
}