using System;
using System.Collections.Generic;
using System.IO;
using BAJIEPA.Tools.Helpers;
using Newtonsoft.Json;
using OrionManager.Common.DataModels;
using OrionManager.Common.Interfaces;
using Unity;

namespace OrionManager.Services.Services.SaveLoad
{
    internal class GameConfigurationJsonService : IGameConfigurationService
    {
        private const string DirectoryName = "GameConfigurations";
        private readonly IUnityContainer _container;

        public GameConfigurationJsonService(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        public IEnumerable<GameConfigurationDataModel> Load()
        {
            var files = Directory.GetFiles(GetConfigurationDirectoryPath());

            foreach (var file in files)
            {
                var json = File.ReadAllText(file);

                GameConfigurationDataModel dataModel = null;

                try
                {
                    dataModel = JsonConvert.DeserializeObject<GameConfigurationDataModel>(json);
                }
                catch (Exception e)
                {
                    this.LogCriticalException(e);
                }

                if (dataModel != null)
                {
                    yield return dataModel;
                }
            }
        }

        public void Delete(Guid id)
        {
            var filePath = GetFileName(id);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            File.Delete(filePath);
        }

        public void Save(GameConfigurationDataModel dataModel)
        {
            var filePath = GetFileName(dataModel.Id);
            var json = JsonConvert.SerializeObject(dataModel);

            File.WriteAllText(filePath, json);
        }

        private string GetConfigurationDirectoryPath() =>
            _container.Resolve<IPathProvider>().GetAppDataDirectoryPath(DirectoryName);

        private string GetFileName(Guid id) => Path.Combine(GetConfigurationDirectoryPath(), id.ToString());
    }
}