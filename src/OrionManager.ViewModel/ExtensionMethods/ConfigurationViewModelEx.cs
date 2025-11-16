using OrionManager.Common.Enums;
using OrionManager.ViewModel.Constants;
using OrionManager.ViewModel.ViewModels;
using Senticode.Wpf;
using System;
using Unity;

namespace OrionManager.ViewModel.ExtensionMethods
{
    internal static class ConfigurationViewModelEx
    {
        public static void SetDefaultValues(this GameConfigurationViewModel item)
        {
            var container = ServiceLocator.Container;

            var player1 = container.Resolve<PlayerPresetViewModel>();
            var player2 = container.Resolve<PlayerPresetViewModel>();

            player1.Race = item.RaceMap[Races.Random];
            player2.Race = item.RaceMap[Races.Random];

            item.PlayerPresets.ReplaceAll(new[] { player1, player2 });
            item.MaxLoyaltyPoints = 10;
            item.MaxWinPoints = 50;
        }

        public static void UpdateIsComplete(this GameConfigurationViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.IsComplete = item.PlayerPresets.Count >= ViewModelConstants.MinPlayerCount;
        }

        public static void OnPlayerPresetsChanged(this GameConfigurationViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.IsPlayerCanBeAdded = item.PlayerPresets.Count < ModuleConstants.MaxPlayerCount;
            item.UpdateIsComplete();
        }
    }
}