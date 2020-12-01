using System;
using OrionManager.DataModels;
using OrionManager.Interfaces;
using Unity;

namespace OrionManager.Services.SaveLoad
{
    internal class GameDataSaveLoadService : ISaveLoadService<GameDataModel>
    {
        public GameDataSaveLoadService(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public GameDataModel Load() => throw new NotImplementedException();

        public void Save(GameDataModel dataModel)
        {
            throw new NotImplementedException();
        }
    }
}