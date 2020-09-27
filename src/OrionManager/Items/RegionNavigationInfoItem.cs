using System;

namespace OrionManager.Items
{
    internal class RegionNavigationInfoItem
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