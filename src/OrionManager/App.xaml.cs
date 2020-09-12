using System.Windows;

namespace OrionManager
{
    internal partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppLifecycleManager.Init(this);

            base.OnStartup(e);

            AppLifecycleManager.OnAppStart();
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            AppLifecycleManager.RegisterTypes();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            AppLifecycleManager.OnAppExit();
        }
    }
}