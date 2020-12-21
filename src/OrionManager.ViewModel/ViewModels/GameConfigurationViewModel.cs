using System;
using System.Collections.Generic;
using System.Windows.Input;
using BAJIEPA.Tools.Helpers;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.Constants;
using OrionManager.ViewModel.ExtensionMethods;
using Senticode.Wpf.Base;
using Senticode.Wpf.Collections;
using Senticode.Wpf.Interfaces;
using Unity;

namespace OrionManager.ViewModel.ViewModels
{
    public class GameConfigurationViewModel : ViewModelBase
    {
        public GameConfigurationViewModel(IUnityContainer container) : base(container)
        {
            PlayerPresets.CollectionChanged += (s, e) => this.OnPlayerPresetsChanged();
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

        public IObservableRangeCollection<PlayerPresetViewModel> PlayerPresets { get; } =
            new ObservableRangeCollection<PlayerPresetViewModel>();

        #region Id: Guid

        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private Guid _id;

        #endregion

        #region IsChosen: bool

        public bool IsChosen
        {
            get => _isChosen;
            set => SetProperty(ref _isChosen, value);
        }

        private bool _isChosen;

        #endregion

        #region IsNotEditable: bool

        public bool IsNotEditable
        {
            get => _isNotEditable;
            set => SetProperty(ref _isNotEditable, value);
        }

        private bool _isNotEditable;

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

        #region MaxWinPoints: int

        public int MaxWinPoints
        {
            get => _maxWinPoints;
            set => SetProperty(ref _maxWinPoints,
                               value.GetInRange(ViewModelConstants.MinConfiguringWinPoints,
                                                ViewModelConstants.MaxConfiguringWinPoints));
        }

        private int _maxWinPoints;

        #endregion

        #region MaxLoyaltyPoints: int

        public int MaxLoyaltyPoints
        {
            get => _maxLoyaltyPoints;
            set => SetProperty(ref _maxLoyaltyPoints,
                               value.GetInRange(ViewModelConstants.MinConfiguringLoyaltyPoints,
                                                ViewModelConstants.MaxConfiguringLoyaltyPoints),
                               OnMaxLoyaltyPointsChanged);
        }

        private void OnMaxLoyaltyPointsChanged()
        {
            this.UpdateIsComplete();
        }

        private int _maxLoyaltyPoints;

        #endregion

        #region IsPlayerCanBeAdded: bool

        public bool IsPlayerCanBeAdded
        {
            get => _isPlayerCanBeAdded;
            set => SetProperty(ref _isPlayerCanBeAdded, value);
        }

        private bool _isPlayerCanBeAdded;

        #endregion

        #region IsComplete: bool

        public bool IsComplete
        {
            get => _isComplete;
            set => SetProperty(ref _isComplete, value);
        }

        private bool _isComplete;

        #endregion

        #region AddPlayer command

        public ICommand AddPlayerCommand => _addPlayerCommand ??=
                                                new SyncCommand(ExecuteAddPlayer);

        private SyncCommand _addPlayerCommand;

        private void ExecuteAddPlayer(object parameter)
        {
            if (!IsPlayerCanBeAdded)
            {
                return;
            }

            PlayerPresets.Add(new PlayerPresetViewModel
            {
                Race = RaceMap[Races.Random]
            });
        }

        #endregion

        #region DeletePlayer command

        public ICommand DeletePlayerCommand => _deletePlayerCommand ??=
                                                   new SyncCommand(ExecuteDeletePlayer);

        private SyncCommand _deletePlayerCommand;

        private void ExecuteDeletePlayer(object parameter)
        {
            if (!(parameter is PlayerPresetViewModel item))
            {
                return;
            }

            RaceMap[item.Race.Value].IsEnabled = true;
            PlayerPresets.Remove(item);
        }

        #endregion
    }
}