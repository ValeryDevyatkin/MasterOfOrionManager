using System;
using OrionManager.Constants;
using OrionManager.DataModels;
using OrionManager.Interfaces;
using Unity;

namespace OrionManager.Services.SaveLoad
{
    internal class GameConfigurationService : IGameConfigurationService
    {
        public GameConfigurationService(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public GameConfigurationDataModel GetDefault() => new GameConfigurationDataModel
        {
            Id = GlobalConstants.DefaultGameConfigurationId,
            Name = StringConstants.DefaultConfigurationName
        };

        public GameConfigurationDataModel[] Load() => new GameConfigurationDataModel[]
        {
            // todo: implement this
        };

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(GameConfigurationDataModel dataModel)
        {
            throw new NotImplementedException();
        }
    }
}