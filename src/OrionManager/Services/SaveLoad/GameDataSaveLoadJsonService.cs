using OrionManager.DataModels;
using Unity;

namespace OrionManager.Services.SaveLoad
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