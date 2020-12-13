using OrionManager.Common.Enums;
using OrionManager.ExtensionMethods;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class PlayerViewModel : ViewModelBase
    {
        public PlayerViewModel(IUnityContainer container) : base(container)
        {
        }

        public string Name { get; set; }
        public PlayerColors Color { get; set; }
        public Races Race { get; set; }

        #region LoyaltyPoints: int

        public int LoyaltyPoints
        {
            get => _loyaltyPoints;
            set => SetProperty(ref _loyaltyPoints, value, OnLoyaltyPointsChanged);
        }

        private void OnLoyaltyPointsChanged()
        {
            Container.Resolve<GameDataViewModel>().UpdateIsGameCanBeFinished();
        }

        private int _loyaltyPoints;

        #endregion

        #region WinPoints: int

        public int WinPoints
        {
            get => _winPoints;
            set => SetProperty(ref _winPoints, value, OnWinPointsChanged);
        }

        private void OnWinPointsChanged()
        {
            Container.Resolve<GameDataViewModel>().UpdateIsGameCanBeFinished();
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