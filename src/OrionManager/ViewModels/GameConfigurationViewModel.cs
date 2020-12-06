using System;
using System.Collections.Generic;
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

        public IReadOnlyDictionary<Race, DisablingItemViewModel<Race>> RaceMap { get; } =
            new Dictionary<Race, DisablingItemViewModel<Race>>
            {
                {Race.Random, new DisablingItemViewModel<Race>(Race.Random)},
                {Race.Human, new DisablingItemViewModel<Race>(Race.Human)},
                {Race.Alkari, new DisablingItemViewModel<Race>(Race.Alkari)},
                {Race.Bulrathi, new DisablingItemViewModel<Race>(Race.Bulrathi)},
                {Race.Darlok, new DisablingItemViewModel<Race>(Race.Darlok)},
                {Race.Meklar, new DisablingItemViewModel<Race>(Race.Meklar)},
                {Race.Mrrshan, new DisablingItemViewModel<Race>(Race.Mrrshan)},
                {Race.Psilon, new DisablingItemViewModel<Race>(Race.Psilon)}
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

        #region IsReadyToPlay: bool

        public bool IsReadyToPlay
        {
            get => _isReadyToPlay;
            set => SetProperty(ref _isReadyToPlay, value);
        }

        private bool _isReadyToPlay;

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
                    Name = GlobalConstants.DefaultPlayerString,
                    Race = RaceMap[Race.Random]
                };

                PlayerPresets.Add(player);
                this.UpdateIsPlayerCanBeAdded();
                this.UpdatePlayerColors();
                this.UpdateIsReadyToPlay();
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
                this.UpdatePlayerColors();
                this.UpdateIsReadyToPlay();
            }
        }

        #endregion
    }
}