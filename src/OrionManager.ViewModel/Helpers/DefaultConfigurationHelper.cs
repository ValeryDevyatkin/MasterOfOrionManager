using OrionManager.Common.DataModels;
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
                PlayerPresets = new PlayerPresetDataModel[] { }
            }.ToViewModel();

            item.IsNotEditable = true;

            return item;
        }
    }
}