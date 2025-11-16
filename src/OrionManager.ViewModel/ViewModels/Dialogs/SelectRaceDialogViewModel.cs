using System.Collections.Generic;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels.Main;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Dialogs
{
    public class SelectRaceDialogViewModel : DialogViewModelBase
    {
        public SelectRaceDialogViewModel(IUnityContainer container) : base(container)
        {
        }

        public IEnumerable<DisablingItemViewModel<Races>> Items =>
            Container.Resolve<MainViewModel>().GameConfiguration.RaceMap.Values;

        public PlayerPresetViewModel Player { get; set; }
    }
}