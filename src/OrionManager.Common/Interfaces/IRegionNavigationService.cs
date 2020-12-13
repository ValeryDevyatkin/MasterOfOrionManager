using System;
using OrionManager.Common.DataItems;

namespace OrionManager.Common.Interfaces
{
    public interface IRegionNavigationService
    {
        RegionNavigationItem NavigateToRegion(Type regionType);
        void Init(params RegionNavigationInfoItem[] regions);
    }
}