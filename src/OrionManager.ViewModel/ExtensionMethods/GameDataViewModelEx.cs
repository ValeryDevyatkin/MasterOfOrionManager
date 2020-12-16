using System.Linq;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ViewModel.ExtensionMethods
{
    internal static class GameDataViewModelEx
    {
        public static void Reset(this GameDataViewModel item)
        {
            item.Round = default;
            item.Players = default;
            item.IsGameCanBeFinished = default;
            item.UpdateRounds();
        }

        public static void UpdateIsGameCanBeFinished(this GameDataViewModel item)
        {
            var mainViewModel = ServiceLocator.Container.Resolve<MainViewModel>();

            if (!mainViewModel.IsGameStarted ||
                item.Players == null)
            {
                return;
            }

            item.IsGameCanBeFinished = item.Round == item.Rounds.Length - 1 ||
                                       item.Players.Any(
                                           x => x.LoyaltyPoints < 0 || x.WinPoints >= item.MaxWinPoint);
        }

        public static void UpdateRounds(this GameDataViewModel item)
        {
            for (var i = 0; i < item.Rounds.Length; i++)
            {
                var round = item.Rounds[i];

                if (i < item.Round)
                {
                    round.State = RoundStates.Passed;
                }
                else if (i == item.Round)
                {
                    round.State = RoundStates.Current;
                }
                else
                {
                    round.State = RoundStates.Arriving;
                }
            }
        }
    }
}