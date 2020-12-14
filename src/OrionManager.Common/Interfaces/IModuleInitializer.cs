using Unity;

namespace OrionManager.Common.Interfaces
{
    public interface IModuleInitializer
    {
        void RegisterTypes(IUnityContainer container);
    }
}