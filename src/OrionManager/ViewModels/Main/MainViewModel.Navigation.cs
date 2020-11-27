using System;
using System.Windows.Input;
using OrionManager.Interfaces;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModels.Main
{
    internal partial class MainViewModel
    {
        #region NavigateToRegion command

        public ICommand NavigateToRegionCommand => _navigateToRegionCommand ??=
                                                       new Command(ExecuteNavigateToRegion);

        private Command _navigateToRegionCommand;

        private void ExecuteNavigateToRegion(object parameter)
        {
            if (!(parameter is Type type))
            {
                return;
            }

            var navigationItem = Container.Resolve<IRegionNavigationService>().NavigateToRegion(type);

            CurrentRegion = navigationItem.Region;
            CurrentRegionBackground = navigationItem.RegionBackground;
        }

        #endregion

        #region CurrentRegionBackground: object

        public object CurrentRegionBackground
        {
            get => _currentRegionBackground;
            private set => SetProperty(ref _currentRegionBackground, value);
        }

        private object _currentRegionBackground;

        #endregion

        #region CurrentRegion: object

        public object CurrentRegion
        {
            get => _currentRegion;
            private set => SetProperty(ref _currentRegion, value);
        }

        private object _currentRegion;

        #endregion
    }
}