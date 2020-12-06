using OrionManager.Enums;
using Senticode.Wpf.Base;

namespace OrionManager.ViewModels
{
    internal class PlayerViewModel : ObservableObject
    {
        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public Race Race { get; set; }

        #region LoyaltyPoints: int

        public int LoyaltyPoints
        {
            get => _loyaltyPoints;
            set => SetProperty(ref _loyaltyPoints, value);
        }

        private int _loyaltyPoints;

        #endregion

        #region WinPoints: int

        public int WinPoints
        {
            get => _winPoints;
            set => SetProperty(ref _winPoints, value);
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

        public DisablingItemViewModel<Counselor> Counselor
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
                Counselor.Value != Enums.Counselor.None)
            {
                Counselor.IsEnabled = false;
            }
        }

        private DisablingItemViewModel<Counselor> _counselor;

        #endregion
    }
}