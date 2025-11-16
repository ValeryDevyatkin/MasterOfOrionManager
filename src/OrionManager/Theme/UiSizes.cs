using System.Windows;

namespace OrionManager.Theme
{
    internal static class UiSizes
    {
        #region Border

        public const double BorderRadiusSize = 5d;
        public const double SmallerBorderRadiusSize = 2d;
        public const double MinimalBorderThicknessSize = 1d;
        public const double BorderThicknessSize = 2d;
        public const double HighlightedBorderThicknessSize = 3d;

        public static readonly CornerRadius BorderRadius = new CornerRadius(BorderRadiusSize);
        public static readonly CornerRadius SmallerBorderRadius = new CornerRadius(SmallerBorderRadiusSize);
        public static readonly Thickness MinimalBorderThickness = new Thickness(MinimalBorderThicknessSize);
        public static readonly Thickness BorderThickness = new Thickness(BorderThicknessSize);
        public static readonly Thickness HighlightedBorderThickness = new Thickness(HighlightedBorderThicknessSize);

        #endregion

        #region Spacing

        public const double TextSpacing = 5d;
        public const double InnerSpacing = 15d;
        public const double OuterSpacing = 30d;

        public static readonly GridLength TextSpacingGridLength = new GridLength(TextSpacing);
        public static readonly GridLength InnerSpacingGridLength = new GridLength(InnerSpacing);
        public static readonly GridLength OuterSpacingGridLength = new GridLength(OuterSpacing);

        public static readonly Thickness TextSpacingThickness = new Thickness(TextSpacing);
        public static readonly Thickness InnerSpacingThickness = new Thickness(InnerSpacing);
        public static readonly Thickness OuterSpacingThickness = new Thickness(OuterSpacing);
        public static readonly Thickness OuterSpacingLeftNegativeThickness = new Thickness(- OuterSpacing, 0, 0, 0);

        #endregion
    }
}