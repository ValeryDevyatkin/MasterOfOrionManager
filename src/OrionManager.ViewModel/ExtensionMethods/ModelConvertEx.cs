using System;
using System.Linq;
using OrionManager.Common.DataModels;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ViewModel.ExtensionMethods
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
            return new GameDataModel
            {
                Round = item.Round,
                WinPointTrackerSize = item.MaxWinPoint,
                LoyaltyTrackerSize = item.MaxLoyaltyPoints,

                Players = item.Players.Select(x => new PlayerDataModel
                {
                    // TODO: Copy fields here.
                    Name = x.Name,
                    Race = x.Race,
                    LoyaltyPoints = x.LoyaltyPoints,
                    WinPoints = x.WinPoints,
                    Color = x.Color,
                    HasInitiative = x.HasInitiative,
                    Counselor = x.Counselor.Value
                }).ToArray()
            };
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
                WinPointTrackerSize = item.MaxWinPoints,
                LoyaltyTrackerSize = item.MaxLoyaltyPoints,

                PlayerPresets = item.PlayerPresets.Select(x => new PlayerPresetDataModel
                {
                    // TODO: Copy fields here.
                    Race = x.Race.Value,
                    Name = x.Name,
                    Color = x.Color
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
            viewModel.MaxWinPoints = item.WinPointTrackerSize;
            viewModel.MaxLoyaltyPoints = item.LoyaltyTrackerSize;

            viewModel.PlayerPresets.AddRange(item.PlayerPresets.Select(x => new PlayerPresetViewModel
            {
                // TODO: Copy fields here.
                Name = x.Name,
                Race = viewModel.RaceMap[x.Race],
                Color = x.Color
            }));

            viewModel.UpdateIsPlayerCanBeAdded();
            viewModel.UpdatePlayerColors();
            viewModel.UpdateIsReadyToPlay();

            return viewModel;
        }
    }
}