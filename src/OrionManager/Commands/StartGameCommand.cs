using System;
using OrionManager.DataModels;
using OrionManager.Enums;
using OrionManager.ExtensionMethods;
using OrionManager.Interfaces;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;
using OrionManager.Views.Regions.Playing;
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

            if (mainViewModel.IsGameStarted ||
                !config.IsReadyToPlay)
            {
                throw new NotSupportedException();
            }

            mainViewModel.IsGameStarted = true;

            for (var i = 0; i < config.PlayerPresets.Count; i++)
            {
                var playerPreset = config.PlayerPresets[i];

                var player = new PlayerViewModel
                {
                    Race = playerPreset.Race.Value,
                    Color = playerPreset.Color,
                    Name = playerPreset.Name,
                    Counselor = game.CounselorMap[Counselor.None]
                };

                players[i] = player;
            }

            game.Players = players;

            var gameDataModel = game.ToDataModel();
            _container.Resolve<ISaveLoadService<GameDataModel>>().Save(gameDataModel);
            _container.Resolve<IDataStateHub<GameDataModel>>().CommitState(gameDataModel);

            mainViewModel.NavigateToRegionCommand.Execute(typeof(PlayingRegion));
        }
    }
}