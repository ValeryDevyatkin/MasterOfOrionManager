using System.Windows;

namespace OrionManager.Constants
{
    internal static class UiSizes
    {
        public const double BorderSize = 2d;
        public const double HighlightedBorderSize = 3d;

        public const double TextSpacing = 5d;
        public const double InnerSpacing = 15d;
        public const double OuterSpacing = 30d;

        public static readonly Thickness BorderThickness = new Thickness(BorderSize);
        public static readonly Thickness HighlightedBorderThickness = new Thickness(HighlightedBorderSize);

        public static readonly GridLength TextSpacingGridLength = new GridLength(TextSpacing);
        public static readonly GridLength InnerSpacingGridLength = new GridLength(InnerSpacing);
        public static readonly GridLength OuterSpacingGridLength = new GridLength(OuterSpacing);

        public static readonly Thickness TextSpacingThickness = new Thickness(TextSpacing);
        public static readonly Thickness InnerSpacingThickness = new Thickness(InnerSpacing);
        public static readonly Thickness OuterSpacingThickness = new Thickness(OuterSpacing);
    }
}