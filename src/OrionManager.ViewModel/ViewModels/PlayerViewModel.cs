using BAJIEPA.Tools.Helpers;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.Constants;
using OrionManager.ViewModel.ExtensionMethods;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        public PlayerViewModel(IUnityContainer container) : base(container)
        {
        }

        private GameDataViewModel GameData => Container.Resolve<GameDataViewModel>();

        public string Name { get; set; }
        public PlayerColors Color { get; set; }
        public Races Race { get; set; }

        #region LoyaltyPoints: int

        public int LoyaltyPoints
        {
            get => _loyaltyPoints;
            set => SetProperty(ref _loyaltyPoints,
                               value.GetInRange(ModuleConstants.MinLoyaltyPoints, GameData.MaxLoyaltyPoints),
                               OnLoyaltyPointsChanged);
        }

        private void OnLoyaltyPointsChanged()
        {
            GameData.UpdateIsGameCanBeFinished();
        }

        private int _loyaltyPoints;

        #endregion

        #region WinPoints: int

        public int WinPoints
        {
            get => _winPoints;
            set => SetProperty(ref _winPoints, value.GetInRange(0, GameData.MaxWinPoint), OnWinPointsChanged);
        }

        private void OnWinPointsChanged()
        {
            GameData.UpdateIsGameCanBeFinished();
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
            if (Counselor != null)
            {
                Counselor.IsEnabled = true;
            }
        }

        private void OnCounselorChanged()
        {
            if (Counselor != null &&
                Counselor.Value != Counselors.None)
            {
                Counselor.IsEnabled = false;
            }
        }

        private DisablingItemViewModel<Counselors> _counselor;

        #endregion
    }
}