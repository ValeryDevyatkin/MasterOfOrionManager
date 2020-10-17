using System;
using OrionManager.DataModels;

namespace OrionManager.Interfaces
{
    internal interface IGameConfigurationService
    {
        GameConfigurationDataModel GetDefault();
        GameConfigurationDataModel[] Load();
        void Delete(Guid id);
        void Save(GameConfigurationDataModel dataModel);
    }
}