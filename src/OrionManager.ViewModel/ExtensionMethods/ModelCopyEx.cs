﻿using System;
using System.Linq;
using OrionManager.Common.DataModels;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ViewModel.ExtensionMethods
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
            target.MaxLoyaltyPoints = source.LoyaltyTrackerSize;
            target.MaxWinPoints = source.WinPointTrackerSize;

            target.Players.ReplaceAll(source.Players.Select(x =>
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
            }));

            target.UpdateRounds();
            target.UpdateIsGameCanBeFinished();
        }

        private static void UpdateRounds(this GameDataViewModel item)
        {
            for (var i = 0; i < item.Rounds.Count; i++)
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