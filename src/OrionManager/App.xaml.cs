using System.Windows;

namespace OrionManager
{
    internal partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppLifecycleManager.Instance.Init(this);

            base.OnStartup(e);

            AppLifecycleManager.Instance.OnAppStart();
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            AppLifecycleManager.Instance.RegisterTypes();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            AppLifecycleManager.Instance.OnAppExit();
        }
    }
}