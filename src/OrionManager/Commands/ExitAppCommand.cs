using Senticode.Tools.Abstractions.Base;
using Unity;

namespace OrionManager.Commands
{
    public class ExitAppCommand : CommandBase
    {
        public ExitAppCommand(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            AppLifecycleManager.Instance.ExitApp();
        }
    }
}