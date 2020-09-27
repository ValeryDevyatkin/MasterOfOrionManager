namespace OrionManager.Items
{
    internal class RegionNavigationItem
    {
        public RegionNavigationItem(object region, object regionBackground)
        {
            Region = region;
            RegionBackground = regionBackground;
        }

        public object Region { get; }
        public object RegionBackground { get; }
    }
}