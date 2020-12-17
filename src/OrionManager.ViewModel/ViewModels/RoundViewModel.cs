using OrionManager.Common.Enums;
using Senticode.Wpf.Base;

namespace OrionManager.ViewModel.ViewModels
{
    public class RoundViewModel : ObservableObject
    {
        #region Number: int

        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        private int _number;

        #endregion

        #region State: RoundState

        public RoundStates State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        private RoundStates _state;

        #endregion
    }
}