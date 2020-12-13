using Unity;

namespace OrionManager.Common.Interfaces
{
    public interface IModuleInitializer
    {
        void Init(IUnityContainer container);
    }
}