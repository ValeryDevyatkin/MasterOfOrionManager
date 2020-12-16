using OrionManager.ViewModel.ViewModels;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ViewModel.ExtensionMethods
{
    internal static class PlayerViewModelEx
    {
        public static void UpdateIsWinPointsValueLeadsToGameFinish(this PlayerViewModel item)
        {
            item.IsWinPointsValueLeadsToGameFinish =
                item.WinPoints >= ServiceLocator.Container.Resolve<GameDataViewModel>().MaxWinPoints;
        }

        public static void UpdateIsLoyaltyPointsValueLeadsToGameFinish(this PlayerViewModel item)
        {
            item.IsLoyaltyPointsValueLeadsToGameFinish = item.LoyaltyPoints < 0;
        }
    }
}