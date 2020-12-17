using System.Collections.Generic;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.Constants;
using OrionManager.ViewModel.ExtensionMethods;
using Senticode.Wpf.Base;
using Senticode.Wpf.Collections;
using Senticode.Wpf.Interfaces;
using Unity;

namespace OrionManager.ViewModel.ViewModels
{
    public class GameDataViewModel : ViewModelBase
    {
        public GameDataViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);

            Players.CollectionChanged += (s, e) => this.UpdatePlayerMap();

            for (var i = 0; i < ModuleConstants.DefaultRoundCount; i++)
            {
                Rounds.Add(new RoundViewModel {Number = i + 1});
            }
        }

        public IReadOnlyDictionary<int, PlayerViewModel> PlayerMap { get; set; }

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

        public IObservableRangeCollection<PlayerViewModel> Players { get; } =
            new ObservableRangeCollection<PlayerViewModel>();

        public IObservableRangeCollection<RoundViewModel> Rounds { get; } =
            new ObservableRangeCollection<RoundViewModel>();

        #region IsOpenedAndReady: bool

        public bool IsOpenedAndReady
        {
            get => _isOpenedAndReady;
            set => SetProperty(ref _isOpenedAndReady, value);
        }

        private bool _isOpenedAndReady;

        #endregion

        #region MaxWinPoints: int

        public int MaxWinPoints
        {
            get => _maxWinPoints;
            set => SetProperty(ref _maxWinPoints, value);
        }

        private int _maxWinPoints;

        #endregion

        #region MaxLoyaltyPoints: int

        public int MaxLoyaltyPoints
        {
            get => _maxLoyaltyPoints;
            set => SetProperty(ref _maxLoyaltyPoints, value);
        }

        private int _maxLoyaltyPoints;

        #endregion

        #region IsLastRound: bool

        public bool IsLastRound
        {
            get => _isLastRound;
            set => SetProperty(ref _isLastRound, value);
        }

        private bool _isLastRound;

        #endregion

        #region Round: int

        public int Round
        {
            get => _round;
            set => SetProperty(ref _round, value, OnRoundChanged);
        }

        private void OnRoundChanged()
        {
            this.UpdateIsLastRound();
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
    }
}