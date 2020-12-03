using OrionManager.Abstract;
using OrionManager.DataModels;
using Unity;

namespace OrionManager.Services.SaveLoad
{
    internal class AppDataSaveLoadJsonService : JsonSaveLoadServiceBase<AppDataModel>
    {
        public AppDataSaveLoadJsonService(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }

        protected override string FileName => "AppData";
    }
}