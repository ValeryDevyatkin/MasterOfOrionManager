using System;
using System.Linq;
using OrionManager.Common.DataModels;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;

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
                WinPointTrackerSize = item.MaxWinPoints,
                LoyaltyTrackerSize = item.MaxLoyaltyPoints,

                Players = item.Players.Select(x => new PlayerDataModel
                {
                    // TODO: Copy fields here.
                    Race = x.Race,
                    LoyaltyPoints = x.LoyaltyPoints,
                    WinPoints = x.WinPoints,
                    Counselor = x.Counselor.Value
                }).ToArray()
            };
        }
    }
}