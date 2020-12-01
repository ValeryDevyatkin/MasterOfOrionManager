using System;
using System.Collections.Generic;
using OrionManager.DataModels;

namespace OrionManager.Interfaces
{
    internal interface IGameConfigurationService
    {
        GameConfigurationDataModel GetDefault();
        IEnumerable<GameConfigurationDataModel> Load();
        void Delete(Guid id);
        void Save(GameConfigurationDataModel dataModel);
    }
}