using System;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ViewModel.ExtensionMethods
{
    internal static class PlayerViewModelEx
    {
        public static bool IsValidCounselorSelected(this PlayerViewModel item) =>
            item.Counselor != null &&
            item.Counselor.Value != Counselors.None;

        public static void UpdateIsWinPointsValueLeadsToGameFinish(this PlayerViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.IsWinPointsValueLeadsToGameFinish =
                item.WinPoints >= ServiceLocator.Container.Resolve<GameDataViewModel>().MaxWinPoints;
        }

        public static void UpdateIsLoyaltyPointsValueLeadsToGameFinish(this PlayerViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.IsLoyaltyPointsValueLeadsToGameFinish = item.LoyaltyPoints < 0;
        }
    }
}