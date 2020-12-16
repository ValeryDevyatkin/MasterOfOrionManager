using System;
using OrionManager.Common.DataModels;
using OrionManager.Services.Abstract;
using Unity;

namespace OrionManager.Services.Services.StateHub
{
    internal class GameDataStateHub : DataStateHubBase<GameDataModel>
    {
        public GameDataStateHub(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        protected override bool HasDifference(GameDataModel item1, GameDataModel item2)
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
            if (item1.Round != item2.Round ||
                item1.LoyaltyTrackerSize != item2.LoyaltyTrackerSize ||
                item1.WinPointTrackerSize != item2.WinPointTrackerSize)
            {
                return true;
            }

            for (var i = 0; i < item1.Players.Length; i++)
            {
                var player1 = item1.Players[i];
                var player2 = item2.Players[i];

                // TODO: Compare fields here.
                if (player1.Counselor != player2.Counselor ||
                    player1.LoyaltyPoints != player2.LoyaltyPoints ||
                    player1.WinPoints != player2.WinPoints)
                {
                    return true;
                }
            }

            return false;
        }
    }
}