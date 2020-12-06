using System.Collections.Generic;
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
    }
}