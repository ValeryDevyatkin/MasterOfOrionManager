using OrionManager.DataModels;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ExtensionMethods
{
    internal static class DataModelConvertEx
    {
        public static AppDataModel ToDataModel(this MainViewModel item) =>
            new AppDataModel
            {
                IsGameStarted = item.IsGameStarted,
                CurrentConfigurationId = item.CurrentConfiguration.Id
            };

        public static GameDataModel ToDataModel(this GameDataViewModel item) =>
            new GameDataModel();

        public static GameConfigurationDataModel ToDataModel(this GameConfigurationViewModel item) =>
            new GameConfigurationDataModel
            {
                Id = item.Id,
                Name = item.Name,
                SaveTime = item.SaveTime
            };

        public static GameConfigurationViewModel ToViewModel(this GameConfigurationDataModel item)
        {
            var viewModel = ServiceLocator.Container.Resolve<GameConfigurationViewModel>();

            viewModel.Id = item.Id;
            viewModel.Name = item.Name;
            viewModel.SaveTime = item.SaveTime;

            return viewModel;
        }
    }
}