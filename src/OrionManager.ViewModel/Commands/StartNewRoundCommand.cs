using System;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.ViewModels;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class StartNewRoundCommand : SyncCommandBase
    {
        private readonly IUnityContainer _container;

        public StartNewRoundCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            var game = _container.Resolve<GameDataViewModel>();

            if (game.IsLastRound)
            {
                throw new NotSupportedException();
            }

            game.GetInitiativePlayer().HasInitiative = false;
            game.Rounds[game.Round].State = RoundStates.Passed;
            game.Round++;
            game.GetInitiativePlayer().HasInitiative = true;
            game.Rounds[game.Round].State = RoundStates.Current;
            game.UpdateIsGameCanBeFinished();
        }
    }
}