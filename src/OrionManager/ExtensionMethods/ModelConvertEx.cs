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
                SaveTime = item.SaveTime,
                Name = item.Name,
                NumberOfRounds = item.NumberOfRounds,
                NumberOfCounselors = item.NumberOfCounselors,
                WinPointTrackerSize = item.WinPointTrackerSize,
                LoyaltyTrackerSize = item.LoyaltyTrackerSize
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
            viewModel.SaveTime = item.SaveTime;
            viewModel.Name = item.Name;
            viewModel.NumberOfRounds = item.NumberOfRounds;
            viewModel.NumberOfCounselors = item.NumberOfCounselors;
            viewModel.WinPointTrackerSize = item.WinPointTrackerSize;
            viewModel.LoyaltyTrackerSize = item.LoyaltyTrackerSize;

            return viewModel;
        }
    }
}