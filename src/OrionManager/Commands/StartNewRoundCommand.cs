using System;
using OrionManager.Enums;
using OrionManager.ExtensionMethods;
using OrionManager.ViewModels;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.Commands
{
    public class StartNewRoundCommand : CommandBase
    {
        private readonly IUnityContainer _container;

        public StartNewRoundCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            var game = _container.Resolve<GameDataViewModel>();

            if (game.Round == game.Rounds.Length)
            {
                throw new NotSupportedException();
            }

            game.Rounds[game.Round].State = RoundState.Passed;
            game.Round++;
            game.Rounds[game.Round].State = RoundState.Current;
            game.UpdateIsGameCanBeFinished();
        }
    }
}