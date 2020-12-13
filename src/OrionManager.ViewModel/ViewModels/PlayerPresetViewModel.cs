using OrionManager.Common.Enums;
using Senticode.Wpf.Base;

namespace OrionManager.ViewModel.ViewModels
{
    public class PlayerPresetViewModel : ObservableObject
    {
        #region Name: string

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _name;

        #endregion

        #region Race: DisablingItemViewModel<Race>

        public DisablingItemViewModel<Races> Race
        {
            get => _race;
            set => SetProperty(ref _race, value, OnRaceChanged, OnRaceChanging);
        }

        private void OnRaceChanging()
        {
            if (Race != null)
            {
                Race.IsEnabled = true;
            }
        }

        private void OnRaceChanged()
        {
            if (Race != null &&
                Race.Value != Races.Random)
            {
                Race.IsEnabled = false;
            }
        }

        private DisablingItemViewModel<Races> _race;

        #endregion

        #region Color: PlayerColor

        public PlayerColors Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        private PlayerColors _color;

        #endregion
    }
}