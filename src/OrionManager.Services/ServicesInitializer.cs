using OrionManager.Common.DataModels;
using OrionManager.Common.Interfaces;
using OrionManager.Services.Services.SaveLoad;
using OrionManager.Services.Services.StateHub;
using Unity;

namespace OrionManager.Services
{
    public class ServicesInitializer : IModuleInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container
               .RegisterType<ISaveLoadService<AppDataModel>, AppDataSaveLoadJsonService>()
               .RegisterType<ISaveLoadService<GameDataModel>, GameDataSaveLoadJsonService>()
               .RegisterType<IDataStateHub<AppDataModel>, AppDataStateHub>()
               .RegisterType<IDataStateHub<GameDataModel>, GameDataStateHub>()
               .RegisterType<IGameConfigurationService, GameConfigurationJsonService>()
               .RegisterType<IPathProvider, PathProvider>()
                ;
        }

        #region singleton

        private ServicesInitializer()
        {
        }

        private static ServicesInitializer _instance;

        public static ServicesInitializer Instance => _instance ??= new ServicesInitializer();

        #endregion
    }
}