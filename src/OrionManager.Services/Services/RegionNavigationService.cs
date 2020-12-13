using System;
using System.Collections.Generic;
using OrionManager.Common.DataItems;
using OrionManager.Common.Enums;
using OrionManager.Common.Interfaces;
using Unity;

namespace OrionManager.Services.Services
{
    internal class RegionNavigationService : IRegionNavigationService
    {
        private readonly IUnityContainer _container;

        private readonly Dictionary<UiRegions, RegionNavigationInfoItem> _regions =
            new Dictionary<UiRegions, RegionNavigationInfoItem>();

        public RegionNavigationService(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        public RegionNavigationItem NavigateToRegion(UiRegions region)
        {
            if (!_regions.TryGetValue(region, out var regionNavigationInfo))
            {
                throw new NotSupportedException();
            }

            var front = _container.Resolve(regionNavigationInfo.Front);
            var back = _container.Resolve(regionNavigationInfo.Back);

            return new RegionNavigationItem(front, back);
        }

        public void Init(params RegionNavigationInfoItem[] regionInfos)
        {
            foreach (var regionInfo in regionInfos)
            {
                _regions.Add(regionInfo.Region, regionInfo);
            }
        }
    }
}