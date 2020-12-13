using System;
using System.Collections.Generic;
using OrionManager.Common.DataItems;
using OrionManager.Common.Interfaces;
using Unity;

namespace OrionManager.Services.Services
{
    internal class RegionNavigationService : IRegionNavigationService
    {
        private readonly IUnityContainer _container;

        private readonly Dictionary<Type, RegionNavigationInfoItem> _regions =
            new Dictionary<Type, RegionNavigationInfoItem>();

        public RegionNavigationService(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        public RegionNavigationItem NavigateToRegion(Type regionType)
        {
            if (!_regions.TryGetValue(regionType, out var regionNavigationInfo))
            {
                throw new NotSupportedException();
            }

            var region = _container.Resolve(regionNavigationInfo.RegionType);
            var regionBackground = _container.Resolve(regionNavigationInfo.RegionBackgroundType);

            return new RegionNavigationItem(region, regionBackground);
        }

        public void Init(params RegionNavigationInfoItem[] regions)
        {
            foreach (var region in regions)
            {
                _regions.Add(region.RegionType, region);
            }
        }
    }
}