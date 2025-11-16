using System;
using System.Collections.Generic;
using System.Linq;
using BAJIEPA.Tools.Helpers;
using OrionManager.Common.DataModels;
using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class StartGameCommand : SyncCommandBase
    {
        private readonly IUnityContainer _container;

        public StartGameCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            var mainViewModel = _container.Resolve<MainViewModel>();
            var config = mainViewModel.GameConfiguration;

            if (!config.IsComplete)
            {
                throw new NotSupportedException();
            }

            mainViewModel.GoToRegion(UiRegions.Playing);
            mainViewModel.IsGameStarted = true;

            var game = mainViewModel.GameData;
            var players = new List<PlayerViewModel>();
            var availableRaces = config.RaceMap.Values
                                       .Where(x => x.Value != Races.Random)
                                       .Where(x => x.IsEnabled)
                                       .ToList();

            game.Reset();
            game.Rounds[0].State = RoundStates.Current;
            game.MaxWinPoints = config.MaxWinPoints;
            game.MaxLoyaltyPoints = config.MaxLoyaltyPoints;

            foreach (var playerPreset in config.PlayerPresets)
            {
                var player = _container.Resolve<PlayerViewModel>();
                var race = playerPreset.Race;

                if (playerPreset.Race.Value == Races.Random)
                {
                    race = availableRaces.GetRandomItem(null);
                    availableRaces.Remove(race);
                }

                player.Race = race.Value;
                player.Counselor = game.CounselorMap[Counselors.None];
                player.LoyaltyPoints = game.MaxLoyaltyPoints;
                player.UpdateIsLoyaltyPointsValueLeadsToGameFinish();
                player.UpdateIsWinPointsValueLeadsToGameFinish();

                players.Add(player);
            }

            game.Players.ReplaceAll(players);
            game.UpdateIsGameCanBeFinished();
            game.GetInitiativePlayer().HasInitiative = true;
            game.IsOpenedAndReady = true;

            var dataModel = game.ToDataModel();

            _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(dataModel);
            _container.Resolve<ISaveLoadService<GameDataModel>>().Save(dataModel);
        }
    }
}