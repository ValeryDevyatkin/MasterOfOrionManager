using System;
using System.Collections.Generic;
using System.Windows.Input;
using OrionManager.Common.Constants;
using OrionManager.Common.Enums;
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

        public IReadOnlyDictionary<Races, DisablingItemViewModel<Races>> RaceMap { get; } =
            new Dictionary<Races, DisablingItemViewModel<Races>>
            {
                {Races.Random, new DisablingItemViewModel<Races>(Races.Random)},
                {Races.Human, new DisablingItemViewModel<Races>(Races.Human)},
                {Races.Alkari, new DisablingItemViewModel<Races>(Races.Alkari)},
                {Races.Bulrathi, new DisablingItemViewModel<Races>(Races.Bulrathi)},
                {Races.Darlok, new DisablingItemViewModel<Races>(Races.Darlok)},
                {Races.Meklar, new DisablingItemViewModel<Races>(Races.Meklar)},
                {Races.Mrrshan, new DisablingItemViewModel<Races>(Races.Mrrshan)},
                {Races.Psilon, new DisablingItemViewModel<Races>(Races.Psilon)}
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
                    Race = RaceMap[Races.Random]
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
                RaceMap[item.Race.Value].IsEnabled = true;
                PlayerPresets.Remove(item);
                this.UpdateIsPlayerCanBeAdded();
                this.UpdatePlayerColors();
                this.UpdateIsReadyToPlay();
            }
        }

        #endregion
    }
}