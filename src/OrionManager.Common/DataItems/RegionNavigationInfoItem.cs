using System;

namespace OrionManager.Common.DataItems
{
    public class RegionNavigationInfoItem
    {
        public RegionNavigationInfoItem(Type regionType, Type regionBackgroundType)
        {
            RegionType = regionType;
            RegionBackgroundType = regionBackgroundType;
        }

        public Type RegionType { get; }
        public Type RegionBackgroundType { get; }
    }
}