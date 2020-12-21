namespace OrionManager.Common.Interfaces
{
    public interface IAppLifecycleService
    {
        void OnStart();
        void OnExit();
        void SaveConfigurationChanges();
    }
}