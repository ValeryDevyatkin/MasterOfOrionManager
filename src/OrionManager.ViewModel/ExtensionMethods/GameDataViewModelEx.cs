using System;
using System.Linq;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels;

namespace OrionManager.ViewModel.ExtensionMethods
{
    internal static class GameDataViewModelEx
    {
        public static void Reset(this GameDataViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.Players.Clear();
            item.MaxLoyaltyPoints = default;
            item.MaxWinPoints = default;
            item.IsOpenedAndReady = default;
            item.Round = default;
            item.IsGameCanBeFinished = default;

            foreach (var round in item.Rounds)
            {
                round.State = RoundStates.Arriving;
            }
        }

        public static void UpdateIsLastRound(this GameDataViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.IsLastRound = item.Round == item.Rounds.Count - 1;
        }

        public static void UpdateIsGameCanBeFinished(this GameDataViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.IsGameCanBeFinished = item.IsLastRound ||
                                       item.Players.Any(
                                           x => x.IsWinPointsValueLeadsToGameFinish ||
                                                x.IsLoyaltyPointsValueLeadsToGameFinish);
        }

        public static PlayerViewModel GetInitiativePlayer(this GameDataViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return item.PlayerMap[item.Round % item.Players.Count];
        }
    }
}