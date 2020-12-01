using System;
using OrionManager.Abstract;
using OrionManager.DataModels;
using Unity;

namespace OrionManager.Services.StateHub
{
    internal class GameDataStateHub : DataStateHubBase<GameDataModel>
    {
        public GameDataStateHub(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        protected override bool DetectChanges(GameDataModel item1, GameDataModel item2)
        {
            if (item1 == null)
            {
                throw new ArgumentNullException(nameof(item1));
            }

            if (item2 == null)
            {
                throw new ArgumentNullException(nameof(item2));
            }

            if (ReferenceEquals(item1, item2))
            {
                throw new ArgumentException(nameof(item2));
            }

            // TODO: Compare fields here.

            return false;
        }
    }
}