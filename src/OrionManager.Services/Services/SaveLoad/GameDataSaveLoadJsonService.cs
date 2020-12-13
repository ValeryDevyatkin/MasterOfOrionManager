using OrionManager.Common.DataModels;
using OrionManager.Services.Abstract;
using Unity;

namespace OrionManager.Services.Services.SaveLoad
{
    internal class GameDataSaveLoadJsonService : JsonSaveLoadServiceBase<GameDataModel>
    {
        public GameDataSaveLoadJsonService(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }

        protected override string FileName => "GameData";
    }
}