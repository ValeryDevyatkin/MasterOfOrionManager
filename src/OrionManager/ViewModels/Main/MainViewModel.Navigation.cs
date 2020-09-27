using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using OrionManager.Enums;
using OrionManager.Views.Backgrounds;
using OrionManager.Views.Regions;
using OrionManager.Views.Regions.Configuration;
using OrionManager.Views.Regions.Playing;
using Senticode.Tools.Abstractions.Base;
using Unity;

namespace OrionManager.ViewModels.Main
{
    internal partial class MainViewModel
    {
        private IReadOnlyDictionary<NavigationRegion, Action> _navigationActions;

        private void InitNavigation()
        {
            _navigationActions = new Dictionary<NavigationRegion, Action>
            {
                {
                    NavigationRegion.Start, () =>
                    {
                        CurrentRegion = Container.Resolve<StartRegion>();
                        CurrentRegionBackground = Container.Resolve<StartBackground>();
                    }
                },
                {
                    NavigationRegion.PreStart, () =>
                    {
                        CurrentRegion = Container.Resolve<PreStartRegion>();
                        CurrentRegionBackground = Container.Resolve<PreStartBackground>();
                    }
                },
                {
                    NavigationRegion.ConfigurationList, () =>
                    {
                        CurrentRegion = Container.Resolve<ConfigurationListRegion>();
                        CurrentRegionBackground = Container.Resolve<ConfigurationBackground>();
                    }
                },
                {
                    NavigationRegion.Configuration, () =>
                    {
                        CurrentRegion = Container.Resolve<ConfigurationRegion>();
                        CurrentRegionBackground = Container.Resolve<ConfigurationBackground>();
                    }
                },
                {
                    NavigationRegion.Playing, () =>
                    {
                        CurrentRegion = Container.Resolve<PlayingRegion>();
                        CurrentRegionBackground = Container.Resolve<PlayingBackground>();
                    }
                }
            };

            NavigateToRegionCommand.Execute(NavigationRegion.Start);
        }

        #region NavigateToRegion command

        public Command<NavigationRegion> NavigateToRegionCommand => _navigateToRegionCommand ??=
                                                                        new Command<NavigationRegion>(
                                                                            ExecuteNavigateToRegion, param => true);

        private Command<NavigationRegion> _navigateToRegionCommand;

        private void ExecuteNavigateToRegion(NavigationRegion param)
        {
            NavigateToRegionCommand.Disable();

            try
            {
                _navigationActions[param]();
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

        #region CurrentRegionBackground: UserControl

        public UserControl CurrentRegionBackground
        {
            get => _currentRegionBackground;
            private set => SetProperty(ref _currentRegionBackground, value);
        }

        private UserControl _currentRegionBackground;

        #endregion

        #region CurrentRegion: UserControl

        public UserControl CurrentRegion
        {
            get => _currentRegion;
            private set => SetProperty(ref _currentRegion, value);
        }

        private UserControl _currentRegion;

        #endregion
    }
}