using System;
using OrionManager.Common.DataModels;
using OrionManager.Services.Abstract;
using Unity;

namespace OrionManager.Services.Services.StateHub
{
    internal class AppDataStateHub : DataStateHubBase<AppDataModel>
    {
        public AppDataStateHub(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        protected override bool HasDifference(AppDataModel item1, AppDataModel item2)
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
            if (item1.IsGameStarted != item2.IsGameStarted ||
                item1.CurrentConfigurationId != item2.CurrentConfigurationId)
            {
                return true;
            }

            return false;
        }
    }
}