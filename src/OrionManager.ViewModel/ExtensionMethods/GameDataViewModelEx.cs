using System.Linq;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels;

namespace OrionManager.ViewModel.ExtensionMethods
{
    internal static class GameDataViewModelEx
    {
        public static void Reset(this GameDataViewModel item)
        {
            item.MaxLoyaltyPoints = default;
            item.MaxWinPoints = default;
            item.IsOpenedAndReady = default;
            item.Round = default;
            item.Players.Clear();
            item.IsGameCanBeFinished = default;

            foreach (var round in item.Rounds)
            {
                round.State = RoundStates.Arriving;
            }
        }

        public static void UpdateIsLastRound(this GameDataViewModel item)
        {
            item.IsLastRound = item.Round == item.Rounds.Count - 1;
        }

        public static void UpdateIsGameCanBeFinished(this GameDataViewModel item)
        {
            item.IsGameCanBeFinished = item.IsLastRound ||
                                       item.Players.Any(
                                           x => x.IsWinPointsValueLeadsToGameFinish ||
                                                x.IsLoyaltyPointsValueLeadsToGameFinish);
        }
    }
}