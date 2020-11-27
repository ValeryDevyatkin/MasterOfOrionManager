using OrionManager.Commands;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager
{
    internal class AppCommands : AppCommandsBase
    {
        public AppCommands(IUnityContainer container) : base(container)
        {
        }

        public ExitAppCommand ExitAppCommand => Container.Resolve<ExitAppCommand>();
    }
}