using System;

namespace OrionManager.Common.Interfaces
{
    public interface IAppLifecycleService
    {
        Action ExitApp { get; set; }
        void OnStart();
        void OnExit();
    }
}