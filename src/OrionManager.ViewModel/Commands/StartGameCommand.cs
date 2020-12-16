using System;
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
            var players = new PlayerViewModel[config.PlayerPresets.Count];

            if (!config.IsReadyToPlay)
            {
                throw new NotSupportedException();
            }

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
            game.MaxWinPoints = config.MaxWinPoints;
            game.MaxLoyaltyPoints = config.MaxLoyaltyPoints;
            game.UpdateRounds();

            var gameDataModel = game.ToDataModel();

            _container.Resolve<ISaveLoadService<GameDataModel>>().Save(gameDataModel);
            _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(gameDataModel);

            mainViewModel.IsGameStarted = true;
            mainViewModel.Region = UiRegions.Playing;
        }
    }
}