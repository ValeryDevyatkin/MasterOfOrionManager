using System.Linq;
using System.Windows;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class FinishGameCommand : SyncCommandBase
    {
        private readonly IUnityContainer _container;

        public FinishGameCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            if (MessageBox.Show("Are you sure?", "Finish Game", MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.No)
            {
                return;
            }

            var game = _container.Resolve<GameDataViewModel>();
            var scoreList = game.Players
                                .Select(PlayerViewModelEx.ToPlayerScore)
                                .OrderByDescending(x => x.Score);

            game.ScoreList.ReplaceAll(scoreList);

            _container.Resolve<MainViewModel>().IsGameStarted = false;
            _container.Resolve<MainViewModel>().Region = UiRegions.Score;
        }
    }
}