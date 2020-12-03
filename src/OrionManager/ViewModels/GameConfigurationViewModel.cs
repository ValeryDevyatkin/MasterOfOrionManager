using System;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class GameConfigurationViewModel : ViewModelBase
    {
        public GameConfigurationViewModel(IUnityContainer container) : base(container)
        {
        }

        public Guid Id { get; set; }

        #region IsChosen: bool

        public bool IsChosen
        {
            get => _isChosen;
            set => SetProperty(ref _isChosen, value);
        }

        private bool _isChosen;

        #endregion

        #region IsDefault: bool

        public bool IsDefault
        {
            get => _isDefault;
            set => SetProperty(ref _isDefault, value);
        }

        private bool _isDefault;

        #endregion

        #region SaveTime: DateTime

        public DateTime SaveTime
        {
            get => _saveTime;
            set => SetProperty(ref _saveTime, value);
        }

        private DateTime _saveTime;

        #endregion

        #region Name: string

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _name;

        #endregion

        #region NumberOfRounds: int

        public int NumberOfRounds
        {
            get => _numberOfRounds;
            set => SetProperty(ref _numberOfRounds, value);
        }

        private int _numberOfRounds;

        #endregion

        #region NumberOfCounselors: int

        public int NumberOfCounselors
        {
            get => _numberOfCounselors;
            set => SetProperty(ref _numberOfCounselors, value);
        }

        private int _numberOfCounselors;

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