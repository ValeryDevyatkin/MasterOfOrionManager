using System.Windows.Input;
using BAJIEPA.Tools.Helpers;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.Constants;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.Interfaces;
using OrionManager.ViewModel.ViewModels.Dialogs;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        public PlayerViewModel(IUnityContainer container) : base(container)
        {
        }

        #region Race: Races

        public Races Race
        {
            get => _race;
            set => SetProperty(ref _race, value);
        }

        private Races _race;

        #endregion

        #region IsWinPointsValueLeadsToGameFinish: bool

        public bool IsWinPointsValueLeadsToGameFinish
        {
            get => _isWinPointsValueLeadsToGameFinish;
            set => SetProperty(ref _isWinPointsValueLeadsToGameFinish, value,
                               OnIsWinPointsValueLeadsToGameFinishChanged);
        }

        private void OnIsWinPointsValueLeadsToGameFinishChanged()
        {
            if (Container.Resolve<GameDataViewModel>().IsOpenedAndReady)
            {
                Container.Resolve<GameDataViewModel>().UpdateIsGameCanBeFinished();
            }
        }

        private bool _isWinPointsValueLeadsToGameFinish;

        #endregion

        #region IsLoyaltyPointsValueLeadsToGameFinish: bool

        public bool IsLoyaltyPointsValueLeadsToGameFinish
        {
            get => _isLoyaltyPointsValueLeadsToGameFinish;
            set => SetProperty(ref _isLoyaltyPointsValueLeadsToGameFinish, value,
                               OnIsLoyaltyPointsValueLeadsToGameFinishChanged);
        }

        private void OnIsLoyaltyPointsValueLeadsToGameFinishChanged()
        {
            if (Container.Resolve<GameDataViewModel>().IsOpenedAndReady)
            {
                Container.Resolve<GameDataViewModel>().UpdateIsGameCanBeFinished();
            }
        }

        private bool _isLoyaltyPointsValueLeadsToGameFinish;

        #endregion

        #region LoyaltyPoints: int

        public int LoyaltyPoints
        {
            get => _loyaltyPoints;
            set => SetProperty(ref _loyaltyPoints,
                               value.GetInRange(ViewModelConstants.MinPlayerLoyaltyPoints,
                                                Container.Resolve<GameDataViewModel>().MaxLoyaltyPoints),
                               OnLoyaltyPointsChanged);
        }

        private void OnLoyaltyPointsChanged()
        {
            this.UpdateIsLoyaltyPointsValueLeadsToGameFinish();
        }

        private int _loyaltyPoints;

        #endregion

        #region WinPoints: int

        public int WinPoints
        {
            get => _winPoints;
            set => SetProperty(ref _winPoints,
                               value.GetInRange(ViewModelConstants.MinPlayerWinPoints,
                                                Container.Resolve<GameDataViewModel>().MaxWinPoints),
                               OnWinPointsChanged);
        }

        private void OnWinPointsChanged()
        {
            this.UpdateIsWinPointsValueLeadsToGameFinish();
        }

        private int _winPoints;

        #endregion

        #region HasInitiative: bool

        public bool HasInitiative
        {
            get => _hasInitiative;
            set => SetProperty(ref _hasInitiative, value);
        }

        private bool _hasInitiative;

        #endregion

        #region Counselor: DisablingItemViewModel<Counselor>

        public DisablingItemViewModel<Counselors> Counselor
        {
            get => _counselor;
            set => SetProperty(ref _counselor, value, OnCounselorChanged, OnCounselorChanging);
        }

        private void OnCounselorChanging()
        {
            if (this.IsValidCounselorSelected())
            {
                Counselor.IsEnabled = true;
            }
        }

        private void OnCounselorChanged()
        {
            if (this.IsValidCounselorSelected())
            {
                Counselor.IsEnabled = false;
            }
        }

        private DisablingItemViewModel<Counselors> _counselor;

        #endregion

        #region SelectCounselor command

        public ICommand SelectCounselorCommand => _selectCounselorCommand ??=
                                                      new SyncCommand(ExecuteSelectCounselor);

        private SyncCommand _selectCounselorCommand;

        private void ExecuteSelectCounselor(object parameter)
        {
            var vm = Container.Resolve<SelectCounselorDialogViewModel>();
            vm.Player = this;
            Container.Resolve<IDialogHost>().ShowDialog(vm);
        }

        #endregion
    }
}