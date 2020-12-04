using System.Collections.Generic;
using System.Windows.Media;
using OrionManager.Enums;

namespace OrionManager.ExtensionMethods
{
    internal static class PlayerColorEx
    {
        private static readonly IReadOnlyDictionary<PlayerColor, Brush> PlayerColorMap =
            new Dictionary<PlayerColor, Brush>
            {
                {PlayerColor.Red, Brushes.Red},
                {PlayerColor.Green, Brushes.Green},
                {PlayerColor.Blue, Brushes.Blue},
                {PlayerColor.Yellow, Brushes.Yellow}
            };

        public static Brush ToBrush(this PlayerColor color) => PlayerColorMap[color];
    }
}