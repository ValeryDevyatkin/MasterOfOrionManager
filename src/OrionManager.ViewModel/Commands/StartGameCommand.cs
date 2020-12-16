using System;
using System.Collections.Generic;
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
            var config = mainViewModel.CurrentConfiguration;
            var game = mainViewModel.GameData;
            var players = new List<PlayerViewModel>();

            if (!config.IsComplete)
            {
                throw new NotSupportedException();
            }

            foreach (var playerPreset in config.PlayerPresets)
            {
                var player = _container.Resolve<PlayerViewModel>();

                player.Race = playerPreset.Race.Value;
                player.Color = playerPreset.Color;
                player.Name = playerPreset.Name;
                player.Counselor = game.CounselorMap[Counselors.None];

                players.Add(player);
            }

            mainViewModel.Region = UiRegions.Playing;
            mainViewModel.IsGameStarted = true;

            game.Reset();
            game.Players.ReplaceAll(players);
            game.Rounds[0].State = RoundStates.Current;
            game.GetInitiativePlayer().HasInitiative = true;
            game.MaxWinPoints = config.MaxWinPoints;
            game.MaxLoyaltyPoints = config.MaxLoyaltyPoints;
            game.IsOpenedAndReady = true;

            var dataModel = game.ToDataModel();

            _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(dataModel);
            _container.Resolve<ISaveLoadService<GameDataModel>>().Save(dataModel);
        }
    }
}