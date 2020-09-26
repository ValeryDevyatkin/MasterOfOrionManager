using System;
using OrionManager.Abstract;
using OrionManager.DataModels;
using Unity;

namespace OrionManager.Services
{
    internal class AppDataStateHub : DataStateHubBase<AppDataModel>
    {
        public AppDataStateHub(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        protected override bool DetectChanges(AppDataModel item1, AppDataModel item2) =>
            throw new NotImplementedException();
    }
}