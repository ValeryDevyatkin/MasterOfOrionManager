using System;
using OrionManager.Common.Enums;

namespace OrionManager.Common.DataItems
{
    public class RegionNavigationInfoItem
    {
        public RegionNavigationInfoItem(UiRegions region, Type front, Type back)
        {
            Front = front;
            Back = back;
            Region = region;
        }

        public UiRegions Region { get; }
        public Type Front { get; }
        public Type Back { get; }
    }
}