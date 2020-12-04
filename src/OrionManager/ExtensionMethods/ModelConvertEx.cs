using System;
using System.Linq;
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

            return new AppDataModel
            {
                // TODO: Copy fields here.
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

            return new GameConfigurationDataModel
            {
                // TODO: Copy fields here.
                Id = item.Id,
                SaveTime = item.SaveTime,
                Name = item.Name,
                NumberOfRounds = item.NumberOfRounds,
                NumberOfCounselors = item.NumberOfCounselors,
                WinPointTrackerSize = item.WinPointTrackerSize,
                LoyaltyTrackerSize = item.LoyaltyTrackerSize,

                PlayerPresets = item.PlayerPresets.Select(x => new PlayerPresetDataModel
                {
                    // TODO: Copy fields here.
                    Race = x.Race.Value,
                    Name = x.Name
                }).ToArray()
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

            viewModel.PlayerPresets.AddRange(item.PlayerPresets.Select(x => new PlayerPresetViewModel
            {
                // TODO: Copy fields here.
                Name = x.Name,
                Race = viewModel.RaceSource[x.Race]
            }));

            viewModel.UpdateIsPlayerCanBeAdded();
            viewModel.UpdatePlayerColors();

            return viewModel;
        }
    }
}