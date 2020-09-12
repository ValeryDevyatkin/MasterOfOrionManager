using System;
using System.Diagnostics;
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

        public override void Execute(object parameter)
        {
            Disable();

            try
            {
                AppLifecycleManager.ExitApp();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                Enable();
            }
        }
    }
}