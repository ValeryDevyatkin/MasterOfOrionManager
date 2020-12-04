using OrionManager.Enums;
using Senticode.Wpf.Base;

namespace OrionManager.ViewModels
{
    internal class PlayerPresetViewModel : ObservableObject
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

        public DisablingItemViewModel<Race> Race
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
            if (Race != null && Race.Item != Enums.Race.Random)
            {
                Race.IsEnabled = false;
            }
        }

        private DisablingItemViewModel<Race> _race;

        #endregion
    }
}