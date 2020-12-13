using OrionManager.Common.DataItems;
using OrionManager.Common.Enums;

namespace OrionManager.Common.Interfaces
{
    public interface IRegionNavigationService
    {
        RegionNavigationItem NavigateToRegion(UiRegions region);
        void Init(params RegionNavigationInfoItem[] regionInfos);
    }
}