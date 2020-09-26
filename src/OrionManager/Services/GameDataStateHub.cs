using System;
using OrionManager.Abstract;
using OrionManager.DataModels;
using Unity;

namespace OrionManager.Services
{
    internal class GameDataStateHub : DataStateHubBase<GameDataModel>
    {
        public GameDataStateHub(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        protected override bool DetectChanges(GameDataModel item1, GameDataModel item2) =>
            throw new NotImplementedException();
    }
}