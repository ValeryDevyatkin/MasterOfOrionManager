using System.Windows;

namespace OrionManager.Constants
{
    internal static class UiSizes
    {
        public const double InnerSpacing = 15d;
        public const double OuterSpacing = 30d;
        public static readonly GridLength InnerSpacingGridLength = new GridLength(InnerSpacing);
        public static readonly GridLength OuterSpacingGridLength = new GridLength(OuterSpacing);
        public static readonly Thickness InnerSpacingThickness = new Thickness(InnerSpacing);
        public static readonly Thickness OuterSpacingThickness = new Thickness(OuterSpacing);

        public static readonly Thickness OuterSpacingLeftRightThickness =
            new Thickness(OuterSpacing, 0d, OuterSpacing, 0d);
    }
}