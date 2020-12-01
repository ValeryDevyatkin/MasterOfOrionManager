using System.IO;
using OrionManager.DataModels;
using OrionManager.Interfaces;
using Unity;

namespace OrionManager.Services.SaveLoad
{
    internal class GameDataSaveLoadJsonService : JsonSaveLoadServiceBase<GameDataModel>
    {
        private const string FileName = "GameData";

        public GameDataSaveLoadJsonService(IUnityContainer container, IPathProvider pathProvider)
        {
            container.RegisterInstance(this);

            FilePath = Path.Combine(pathProvider.GetAppDataDirectoryPath(), FileName);
        }
    }
}