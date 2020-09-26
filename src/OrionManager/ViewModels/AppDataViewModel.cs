using OrionManager.DataModels;
using OrionManager.Interfaces;
using Senticode.Tools.WPF.MVVM.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class AppDataViewModel : ViewModelBase, ICopyFrom<AppDataModel>
    {
        public AppDataViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }

        public void CopyFrom(AppDataModel dataModel)
        {
            IsGameStarted = dataModel.IsGameStarted;
        }

        #region IsGameStarted: bool

        public bool IsGameStarted
        {
            get => _isGameStarted;
            private set => SetProperty(ref _isGameStarted, value);
        }

        private bool _isGameStarted;

        #endregion
    }
}