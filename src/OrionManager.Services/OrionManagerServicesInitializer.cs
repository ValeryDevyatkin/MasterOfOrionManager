using OrionManager.Common.DataModels;
using OrionManager.Common.Interfaces;
using OrionManager.Services.Services;
using OrionManager.Services.Services.SaveLoad;
using OrionManager.Services.Services.StateHub;
using Unity;

namespace OrionManager.Services
{
    public class OrionManagerServicesInitializer : IModuleInitializer
    {
        public void Init(IUnityContainer container)
        {
            container
               .RegisterType<ISaveLoadService<AppDataModel>, AppDataSaveLoadJsonService>()
               .RegisterType<ISaveLoadService<GameDataModel>, GameDataSaveLoadJsonService>()
               .RegisterType<IDataStateHub<AppDataModel>, AppDataStateHub>()
               .RegisterType<IDataStateHub<GameDataModel>, GameDataStateHub>()
               .RegisterType<IRegionNavigationService, RegionNavigationService>()
               .RegisterType<IGameConfigurationService, GameConfigurationJsonService>()
               .RegisterType<IPathProvider, PathProvider>()
                ;
        }

        #region singleton

        private OrionManagerServicesInitializer()
        {
        }

        public static OrionManagerServicesInitializer Instance { get; } = new OrionManagerServicesInitializer();

        #endregion
    }
}