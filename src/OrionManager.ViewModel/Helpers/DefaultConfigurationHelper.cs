using OrionManager.Common.DataModels;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.Constants;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.ViewModels;

namespace OrionManager.ViewModel.Helpers
{
    internal static class DefaultConfigurationHelper
    {
        public static GameConfigurationViewModel GetDefaultConfigurationViewModel()
        {
            var item = new GameConfigurationDataModel
            {
                Name = ModuleConstants.DefaultConfigurationName,
                PlayerPresets = new[]
                {
                    new PlayerPresetDataModel {Race = Races.Random},
                    new PlayerPresetDataModel {Race = Races.Random},
                    new PlayerPresetDataModel {Race = Races.Random}
                },
                LoyaltyTrackerSize = 8,
                WinPointTrackerSize = 50
            }.ToViewModel();

            item.IsNotEditable = true;

            return item;
        }
    }
}