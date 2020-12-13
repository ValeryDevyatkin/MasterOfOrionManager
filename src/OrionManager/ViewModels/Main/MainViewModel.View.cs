namespace OrionManager.ViewModels.Main
{
    internal partial class MainViewModel
    {
        #region CurrentRegionBackground: object

        public object CurrentRegionBackground
        {
            get => _currentRegionBackground;
            set => SetProperty(ref _currentRegionBackground, value);
        }

        private object _currentRegionBackground;

        #endregion

        #region CurrentRegion: object

        public object CurrentRegion
        {
            get => _currentRegion;
            set => SetProperty(ref _currentRegion, value);
        }

        private object _currentRegion;

        #endregion
    }
}