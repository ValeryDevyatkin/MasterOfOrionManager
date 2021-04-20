using System;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.Constants;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Main
{
    public partial class MainViewModel : ViewModelBase
    {
        /// <summary>
        ///     Design data stub. Do not use!
        /// </summary>
        public MainViewModel() : base(null)
        {
            throw new NotImplementedException();
        }

        public MainViewModel(IUnityContainer container) : base(container)
        {
            Title = ModuleConstants.AppName;
        }

        public GameDataViewModel GameData => Container.Resolve<GameDataViewModel>();

        #region IsGameStarted: bool

        public bool IsGameStarted
        {
            get => _isGameStarted;
            set => SetProperty(ref _isGameStarted, value);
        }

        private bool _isGameStarted;

        #endregion

        #region Region: UiRegions

        public UiRegions Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        private UiRegions _region;

        #endregion

        #region Title: string

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _title;

        #endregion
    }
}