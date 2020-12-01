using System;
using OrionManager.DataItems;

namespace OrionManager.Interfaces
{
    internal interface IRegionNavigationService
    {
        RegionNavigationItem NavigateToRegion(Type regionType);
        void Init(params RegionNavigationInfoItem[] regions);
    }
}