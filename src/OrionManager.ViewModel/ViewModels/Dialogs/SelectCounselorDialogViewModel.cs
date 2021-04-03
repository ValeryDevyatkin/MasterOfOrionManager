using System.Collections.Generic;
using OrionManager.Common.Enums;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Dialogs
{
    public class SelectCounselorDialogViewModel : DialogViewModelBase
    {
        public SelectCounselorDialogViewModel(IUnityContainer container) : base(container)
        {
        }

        public IEnumerable<DisablingItemViewModel<Counselors>> Items =>
            Container.Resolve<GameDataViewModel>().CounselorMap.Values;

        public PlayerViewModel Player { get; set; }
    }
}