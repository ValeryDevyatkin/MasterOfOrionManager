using System.Linq;
using System.Windows.Input;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Dialogs
{
    public class FinishGameDialogViewModel : DialogViewModelBase
    {
        public FinishGameDialogViewModel(IUnityContainer container) : base(container)
        {
        }

        #region FinishGame command

        public ICommand FinishGameCommand => _finishGameCommand ??=
            new SyncCommand(ExecuteFinishGame);

        private SyncCommand _finishGameCommand;

        private void ExecuteFinishGame(object parameter)
        {
            CloseDialog();

            var game = Container.Resolve<GameDataViewModel>();
            var scoreList = game.Players
                                .Select(PlayerViewModelEx.ToPlayerScore)
                                .OrderByDescending(x => x.Score);

            game.ScoreList.ReplaceAll(scoreList);

            Container.Resolve<MainViewModel>().IsGameStarted = false;
            Container.Resolve<MainViewModel>().Region = UiRegions.Score;
        }

        #endregion
    }
}