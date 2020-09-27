using System;
using OrionManager.Items;

namespace OrionManager.Interfaces
{
    internal interface IRegionNavigationService
    {
        RegionNavigationItem NavigateToRegion(Type regionType);
        void Init(params RegionNavigationInfoItem[] regions);
    }
}