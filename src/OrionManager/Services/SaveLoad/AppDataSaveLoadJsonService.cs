using System.IO;
using OrionManager.DataModels;
using OrionManager.Interfaces;
using Unity;

namespace OrionManager.Services.SaveLoad
{
    internal class AppDataSaveLoadJsonService : JsonSaveLoadServiceBase<AppDataModel>
    {
        private const string FileName = "AppData";

        public AppDataSaveLoadJsonService(IUnityContainer container, IPathProvider pathProvider)
        {
            container.RegisterInstance(this);

            FilePath = Path.Combine(pathProvider.GetAppDataDirectoryPath(), FileName);
        }
    }
}