using System.Collections.Generic;
using OrionManager.Common.Constants;
using OrionManager.Common.Enums;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels
{
    public class GameDataViewModel : ViewModelBase
    {
        public GameDataViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);

            for (var i = 0; i < GlobalConstants.DefaultRoundCount; i++)
            {
                Rounds[i] = new RoundViewModel {Number = i + 1};
            }
        }

        public IReadOnlyDictionary<Counselors, DisablingItemViewModel<Counselors>> CounselorMap { get; } =
            new Dictionary<Counselors, DisablingItemViewModel<Counselors>>
            {
                {Counselors.None, new DisablingItemViewModel<Counselors>(Counselors.None)},
                {Counselors.Advia, new DisablingItemViewModel<Counselors>(Counselors.Advia)},
                {Counselors.Veil, new DisablingItemViewModel<Counselors>(Counselors.Veil)},
                {Counselors.Harrava, new DisablingItemViewModel<Counselors>(Counselors.Harrava)},
                {Counselors.Kual, new DisablingItemViewModel<Counselors>(Counselors.Kual)},
                {Counselors.Moldred, new DisablingItemViewModel<Counselors>(Counselors.Moldred)},
                {Counselors.Alluvia, new DisablingItemViewModel<Counselors>(Counselors.Alluvia)},
                {Counselors.Kuruk, new DisablingItemViewModel<Counselors>(Counselors.Kuruk)},
                {Counselors.Viktoria, new DisablingItemViewModel<Counselors>(Counselors.Viktoria)}
            };

        public PlayerViewModel[] Players { get; set; }

        public RoundViewModel[] Rounds { get; } = new RoundViewModel[GlobalConstants.DefaultRoundCount];

        #region Round: int

        public int Round
        {
            get => _round;
            set => SetProperty(ref _round, value);
        }

        private int _round;

        #endregion

        #region IsGameCanBeFinished: bool

        public bool IsGameCanBeFinished
        {
            get => _isGameCanBeFinished;
            set => SetProperty(ref _isGameCanBeFinished, value);
        }

        private bool _isGameCanBeFinished;

        #endregion

        #region WinPointTrackerSize: int

        public int WinPointTrackerSize
        {
            get => _winPointTrackerSize;
            set => SetProperty(ref _winPointTrackerSize, value);
        }

        private int _winPointTrackerSize;

        #endregion

        #region LoyaltyTrackerSize: int

        public int LoyaltyTrackerSize
        {
            get => _loyaltyTrackerSize;
            set => SetProperty(ref _loyaltyTrackerSize, value);
        }

        private int _loyaltyTrackerSize;

        #endregion
    }
}