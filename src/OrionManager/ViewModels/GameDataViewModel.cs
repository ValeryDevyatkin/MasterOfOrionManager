using System.Collections.Generic;
using OrionManager.Constants;
using OrionManager.Enums;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class GameDataViewModel : ViewModelBase
    {
        public GameDataViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);

            for (var i = 0; i < GlobalConstants.RoundCount; i++)
            {
                Rounds[i] = new RoundViewModel {Number = i + 1};
            }
        }

        public IReadOnlyDictionary<Counselor, DisablingItemViewModel<Counselor>> CounselorMap { get; } =
            new Dictionary<Counselor, DisablingItemViewModel<Counselor>>
            {
                {Counselor.None, new DisablingItemViewModel<Counselor>(Counselor.None)},
                {Counselor.Advia, new DisablingItemViewModel<Counselor>(Counselor.Advia)},
                {Counselor.Veil, new DisablingItemViewModel<Counselor>(Counselor.Veil)},
                {Counselor.Harrava, new DisablingItemViewModel<Counselor>(Counselor.Harrava)},
                {Counselor.Kual, new DisablingItemViewModel<Counselor>(Counselor.Kual)},
                {Counselor.Moldred, new DisablingItemViewModel<Counselor>(Counselor.Moldred)},
                {Counselor.Alluvia, new DisablingItemViewModel<Counselor>(Counselor.Alluvia)},
                {Counselor.Kuruk, new DisablingItemViewModel<Counselor>(Counselor.Kuruk)},
                {Counselor.Viktoria, new DisablingItemViewModel<Counselor>(Counselor.Viktoria)}
            };

        public PlayerViewModel[] Players { get; set; }

        public RoundViewModel[] Rounds { get; } = new RoundViewModel[GlobalConstants.RoundCount];

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