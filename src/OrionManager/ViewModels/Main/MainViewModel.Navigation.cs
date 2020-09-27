using System;
using System.Diagnostics;
using OrionManager.Interfaces;
using Senticode.Tools.Abstractions.Base;
using Unity;

namespace OrionManager.ViewModels.Main
{
    internal partial class MainViewModel
    {
        #region NavigateToRegion command

        public Command<Type> NavigateToRegionCommand => _navigateToRegionCommand ??=
                                                            new Command<Type>(
                                                                ExecuteNavigateToRegion, param => true);

        private Command<Type> _navigateToRegionCommand;

        private void ExecuteNavigateToRegion(Type param)
        {
            NavigateToRegionCommand.Disable();

            try
            {
                var navigationItem = Container.Resolve<IRegionNavigationService>().NavigateToRegion(param);

                CurrentRegion = navigationItem.Region;
                CurrentRegionBackground = navigationItem.RegionBackground;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                NavigateToRegionCommand.Enable();
            }
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