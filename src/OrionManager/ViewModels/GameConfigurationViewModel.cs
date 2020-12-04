using System;
using System.Windows.Input;
using OrionManager.Constants;
using OrionManager.Enums;
using OrionManager.ExtensionMethods;
using Senticode.Wpf.Base;
using Senticode.Wpf.Collections;
using Unity;

namespace OrionManager.ViewModels
{
    internal class GameConfigurationViewModel : ViewModelBase
    {
        public GameConfigurationViewModel(IUnityContainer container) : base(container)
        {
            this.UpdateIsPlayerCanBeAdded();
        }

        public DisablingItemViewModel<Race>[] RaceSource { get; } =
        {
            new DisablingItemViewModel<Race>(Race.Random),
            new DisablingItemViewModel<Race>(Race.Human),
            new DisablingItemViewModel<Race>(Race.Alkari),
            new DisablingItemViewModel<Race>(Race.Bulrathi),
            new DisablingItemViewModel<Race>(Race.Darlok),
            new DisablingItemViewModel<Race>(Race.Meklar),
            new DisablingItemViewModel<Race>(Race.Mrrshan),
            new DisablingItemViewModel<Race>(Race.Psilon)
        };

        public ObservableRangeCollection<PlayerPresetViewModel> PlayerPresets { get; } =
            new ObservableRangeCollection<PlayerPresetViewModel>();

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

        #region IsPlayerCanBeAdded: bool

        public bool IsPlayerCanBeAdded
        {
            get => _isPlayerCanBeAdded;
            set => SetProperty(ref _isPlayerCanBeAdded, value);
        }

        private bool _isPlayerCanBeAdded;

        #endregion

        #region AddPlayer command

        public ICommand AddPlayerCommand => _addPlayerCommand ??=
                                                new Command(ExecuteAddPlayer);

        private Command _addPlayerCommand;

        private void ExecuteAddPlayer(object parameter)
        {
            if (IsPlayerCanBeAdded)
            {
                var player = new PlayerPresetViewModel
                {
                    Name = $"{GlobalConstants.DefaultPlayerString} {PlayerPresets.Count + 1}"
                };

                PlayerPresets.Add(player);
                this.UpdateIsPlayerCanBeAdded();
            }
        }

        #endregion

        #region DeletePlayer command

        public ICommand DeletePlayerCommand => _deletePlayerCommand ??=
                                                   new Command(ExecuteDeletePlayer);

        private Command _deletePlayerCommand;

        private void ExecuteDeletePlayer(object parameter)
        {
            if (parameter is PlayerPresetViewModel item)
            {
                PlayerPresets.Remove(item);
                this.UpdateIsPlayerCanBeAdded();
            }
        }

        #endregion
    }
}