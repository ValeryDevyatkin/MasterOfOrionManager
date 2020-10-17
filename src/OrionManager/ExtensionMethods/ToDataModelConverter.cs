using OrionManager.DataModels;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;

namespace OrionManager.ExtensionMethods
{
    internal static class ToDataModelConverter
    {
        public static AppDataModel ToDataModel(this MainViewModel viewModel) =>
            new AppDataModel
            {
                IsGameStarted = viewModel.IsGameStarted,
                CurrentConfigurationId = viewModel.CurrentConfiguration.Id
            };

        public static GameDataModel ToDataModel(this GameDataViewModel viewModel) =>
            new GameDataModel();

        public static GameConfigurationDataModel ToDataModel(this GameConfigurationViewModel viewModel) =>
            new GameConfigurationDataModel
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                SaveTime = viewModel.SaveTime
            };
    }
}