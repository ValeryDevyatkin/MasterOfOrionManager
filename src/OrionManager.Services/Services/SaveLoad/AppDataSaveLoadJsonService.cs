using OrionManager.Common.DataModels;
using OrionManager.Services.Abstract;
using Unity;

namespace OrionManager.Services.Services.SaveLoad
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