using System.Windows.Input;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.Interfaces;
using OrionManager.ViewModel.ViewModels.Dialogs;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels
{
    public class PlayerPresetViewModel : ViewModelBase
    {
        public PlayerPresetViewModel(IUnityContainer container) : base(container)
        {
        }

        #region Race: DisablingItemViewModel<Race>

        public DisablingItemViewModel<Races> Race
        {
            get => _race;
            set => SetProperty(ref _race, value, OnRaceChanged, OnRaceChanging);
        }

        private void OnRaceChanging()
        {
            if (Race != null)
            {
                Race.IsEnabled = true;
            }
        }

        private void OnRaceChanged()
        {
            if (Race != null &&
                Race.Value != Races.Random)
            {
                Race.IsEnabled = false;
            }
        }

        private DisablingItemViewModel<Races> _race;

        #endregion

        #region SelectRace command

        public ICommand SelectRaceCommand => _selectRaceCommand ??=
                                                 new SyncCommand(ExecuteSelectRace);

        private SyncCommand _selectRaceCommand;

        private void ExecuteSelectRace(object parameter)
        {
            var vm = Container.Resolve<SelectRaceDialogViewModel>();
            vm.Player = this;
            Container.Resolve<IDialogHost>().ShowDialog(vm);
        }

        #endregion
    }
}