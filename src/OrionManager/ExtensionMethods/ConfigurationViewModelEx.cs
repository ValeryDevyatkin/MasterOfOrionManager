using System;
using OrionManager.Constants;
using OrionManager.Enums;
using OrionManager.ViewModels;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ExtensionMethods
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
            target.Name = source.Name;
            target.NumberOfRounds = source.NumberOfRounds;
            target.NumberOfCounselors = source.NumberOfCounselors;
            target.WinPointTrackerSize = source.WinPointTrackerSize;
            target.LoyaltyTrackerSize = source.LoyaltyTrackerSize;
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
                item1.NumberOfRounds != item2.NumberOfRounds ||
                item1.NumberOfCounselors != item2.NumberOfCounselors ||
                item1.WinPointTrackerSize != item2.WinPointTrackerSize ||
                item1.LoyaltyTrackerSize != item2.LoyaltyTrackerSize)
            {
                return true;
            }

            return false;
        }

        public static void UpdateIsPlayerCanBeAdded(this GameConfigurationViewModel item)
        {
            item.IsPlayerCanBeAdded = item.PlayerPresets.Count < GlobalConstants.MaxPlayerCount;
        }

        public static void UpdatePlayerColors(this GameConfigurationViewModel item)
        {
            for (var i = 0; i < item.PlayerPresets.Count; i++)
            {
                item.PlayerPresets[i].Color = (PlayerColor) i;
            }
        }
    }
}