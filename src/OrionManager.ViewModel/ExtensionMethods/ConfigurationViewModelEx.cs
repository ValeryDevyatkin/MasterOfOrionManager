using System;
using System.Linq;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.Constants;
using OrionManager.ViewModel.ViewModels;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ViewModel.ExtensionMethods
{
    internal static class ConfigurationViewModelEx
    {
        public static void CopyFrom(this GameConfigurationViewModel target, GameConfigurationViewModel source)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (ReferenceEquals(target, source))
            {
                throw new ArgumentException(nameof(source));
            }

            // TODO: Copy fields here.
            target.SaveTime = source.SaveTime;
            target.Name = source.Name.Trim();
            target.MaxWinPoints = source.MaxWinPoints;
            target.MaxLoyaltyPoints = source.MaxLoyaltyPoints;
            target.PlayerPresets.ReplaceAll(source.PlayerPresets.Select(x => new PlayerPresetViewModel
            {
                // TODO: Copy fields here.
                Race = target.RaceMap[x.Race.Value],
                Name = x.Name.Trim(),
                Color = x.Color
            }));

            target.UpdateIsPlayerCanBeAdded();
            target.UpdatePlayerColors();
            target.UpdateIsReadyToPlay();
        }

        public static GameConfigurationViewModel Clone(this GameConfigurationViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var viewModel = ServiceLocator.Container.Resolve<GameConfigurationViewModel>();

            viewModel.CopyFrom(item);

            return viewModel;
        }

        public static bool HasDifference(this GameConfigurationViewModel item1, GameConfigurationViewModel item2)
        {
            if (item1 == null)
            {
                throw new ArgumentNullException(nameof(item1));
            }

            if (item2 == null)
            {
                throw new ArgumentNullException(nameof(item2));
            }

            if (ReferenceEquals(item1, item2))
            {
                throw new ArgumentException(nameof(item2));
            }

            // TODO: Compare fields here.
            if (item1.Name != item2.Name ||
                item1.MaxWinPoints != item2.MaxWinPoints ||
                item1.MaxLoyaltyPoints != item2.MaxLoyaltyPoints ||
                item1.PlayerPresets.Count != item2.PlayerPresets.Count)
            {
                return true;
            }

            for (var i = 0; i < item1.PlayerPresets.Count; i++)
            {
                var playerPreset1 = item1.PlayerPresets[i];
                var playerPreset2 = item2.PlayerPresets[i];

                // TODO: Compare fields here.
                if (playerPreset1.Race.Value != playerPreset2.Race.Value ||
                    playerPreset1.Name != playerPreset2.Name ||
                    playerPreset1.Color != playerPreset2.Color)
                {
                    return true;
                }
            }

            return false;
        }

        public static void UpdateIsPlayerCanBeAdded(this GameConfigurationViewModel item)
        {
            item.IsPlayerCanBeAdded = item.PlayerPresets.Count < ModuleConstants.MaxPlayerCount;
        }

        public static void UpdatePlayerColors(this GameConfigurationViewModel item)
        {
            for (var i = 0; i < item.PlayerPresets.Count; i++)
            {
                item.PlayerPresets[i].Color = (PlayerColors) i;
            }
        }

        public static void UpdateIsReadyToPlay(this GameConfigurationViewModel item) =>
            item.IsReadyToPlay = item.PlayerPresets.Count > 0;
    }
}