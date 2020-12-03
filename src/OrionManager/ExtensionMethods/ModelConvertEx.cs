using System;
using OrionManager.DataModels;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ExtensionMethods
{
    internal static class ModelConvertEx
    {
        public static AppDataModel ToDataModel(this MainViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // TODO: Copy fields here.
            return new AppDataModel
            {
                IsGameStarted = item.IsGameStarted,
                CurrentConfigurationId = item.CurrentConfiguration.Id
            };
        }

        public static GameDataModel ToDataModel(this GameDataViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // TODO: Copy fields here.
            return new GameDataModel();
        }

        public static GameConfigurationDataModel ToDataModel(this GameConfigurationViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // TODO: Copy fields here.
            return new GameConfigurationDataModel
            {
                Id = item.Id,
                Name = item.Name,
                SaveTime = item.SaveTime
            };
        }

        public static GameConfigurationViewModel ToViewModel(this GameConfigurationDataModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var viewModel = ServiceLocator.Container.Resolve<GameConfigurationViewModel>();

            // TODO: Copy fields here.

            viewModel.Id = item.Id;
            viewModel.Name = item.Name;
            viewModel.SaveTime = item.SaveTime;

            return viewModel;
        }
    }
}