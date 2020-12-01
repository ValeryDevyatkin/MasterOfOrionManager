using System;
using System.Collections.Generic;
using System.IO;
using BAJIEPA.Tools.Helpers;
using Newtonsoft.Json;
using OrionManager.Constants;
using OrionManager.DataModels;
using OrionManager.Interfaces;
using Unity;

namespace OrionManager.Services.SaveLoad
{
    internal class GameConfigurationJsonService : IGameConfigurationService
    {
        private const string DefaultConfigurationName = "Default";
        private const string DirectoryName = "GameConfigurations";
        private readonly string _directoryPath;

        public GameConfigurationJsonService(IUnityContainer container, IPathProvider pathProvider)
        {
            container.RegisterInstance(this);

            _directoryPath = Path.Combine(pathProvider.GetAppDataDirectoryPath(), DirectoryName);
        }

        public GameConfigurationDataModel GetDefault() => new GameConfigurationDataModel
        {
            Id = GlobalConstants.DefaultGameConfigurationId,
            Name = DefaultConfigurationName
        };

        public IEnumerable<GameConfigurationDataModel> Load()
        {
            if (!Directory.Exists(_directoryPath))
            {
                yield break;
            }

            var files = Directory.GetFiles(_directoryPath);

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

        private string GetFileName(Guid id) => Path.Combine(_directoryPath, id.ToString());
    }
}