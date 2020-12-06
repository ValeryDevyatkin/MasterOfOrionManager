using OrionManager.Enums;
using Senticode.Wpf.Base;

namespace OrionManager.ViewModels
{
    internal class RoundViewModel : ObservableObject
    {
        public int Number { get; set; }

        #region State: RoundState

        public RoundState State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        private RoundState _state;

        #endregion
    }
}