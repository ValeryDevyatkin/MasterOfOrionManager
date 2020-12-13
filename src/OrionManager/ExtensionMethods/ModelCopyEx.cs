using System;
using System.Linq;
using OrionManager.Common.DataModels;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ExtensionMethods
{
    internal static class ModelCopyEx
    {
        public static void CopyFrom(this MainViewModel target, AppDataModel source)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // TODO: Copy fields here.
            target.IsGameStarted = source.IsGameStarted;
        }

        public static void CopyFrom(this GameDataViewModel target, GameDataModel source)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // TODO: Copy fields here.
            target.Round = source.Round;
            target.LoyaltyTrackerSize = source.LoyaltyTrackerSize;
            target.WinPointTrackerSize = source.WinPointTrackerSize;

            target.Players = source.Players.Select(x =>
            {
                var viewModel = ServiceLocator.Container.Resolve<PlayerViewModel>();

                // TODO: Copy fields here.
                viewModel.Name = x.Name;
                viewModel.Race = x.Race;
                viewModel.LoyaltyPoints = x.LoyaltyPoints;
                viewModel.WinPoints = x.WinPoints;
                viewModel.Color = x.Color;
                viewModel.HasInitiative = x.HasInitiative;
                viewModel.Counselor = target.CounselorMap[x.Counselor];

                return viewModel;
            }).ToArray();

            target.UpdateRounds();
            target.UpdateIsGameCanBeFinished();
        }
    }
}