using System.Windows;

namespace OrionManager
{
    internal partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppLifecycleManager.OnStart(this);
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            AppLifecycleManager.RegisterTypes(this);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            AppLifecycleManager.OnExit(this);
        }
    }
}