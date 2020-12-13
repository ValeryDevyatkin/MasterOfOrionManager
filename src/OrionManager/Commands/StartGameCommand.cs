using System;
using OrionManager.Common.DataModels;
using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using OrionManager.ExtensionMethods;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.Commands
{
    public class StartGameCommand : CommandBase
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
            var players = new PlayerViewModel[config.PlayerPresets.Count];

            if (!config.IsReadyToPlay)
            {
                throw new NotSupportedException();
            }

            mainViewModel.IsGameStarted = true;

            for (var i = 0; i < config.PlayerPresets.Count; i++)
            {
                var playerPreset = config.PlayerPresets[i];
                var player = _container.Resolve<PlayerViewModel>();

                player.Race = playerPreset.Race.Value;
                player.Color = playerPreset.Color;
                player.Name = playerPreset.Name;
                player.Counselor = game.CounselorMap[Counselors.None];

                players[i] = player;
            }

            game.Reset();
            game.Players = players;
            game.WinPointTrackerSize = config.WinPointTrackerSize;
            game.LoyaltyTrackerSize = config.LoyaltyTrackerSize;
            game.UpdateRounds();

            var gameDataModel = game.ToDataModel();

            _container.Resolve<ISaveLoadService<GameDataModel>>().Save(gameDataModel);
            _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(gameDataModel);
            _container.Resolve<NavigateToRegionCommand>().Execute(UiRegions.Playing);
        }
    }
}