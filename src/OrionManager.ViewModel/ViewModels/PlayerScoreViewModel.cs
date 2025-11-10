using OrionManager.Common.Enums;
using Senticode.Wpf.Base;

namespace OrionManager.ViewModel.ViewModels
{
    public class PlayerScoreViewModel : ObservableObject
    {
        #region Race: Races

        public Races Race
        {
            get => _race;
            set => SetProperty(ref _race, value);
        }

        private Races _race;

        #endregion

        #region Score: int

        public int Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }

        private int _score;

        #endregion
    }
}