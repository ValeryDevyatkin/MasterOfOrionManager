using System;

namespace OrionManager.ExtensionMethods
{
    internal static class GuidEx
    {
        public static string GetHead(this Guid guid) => guid.ToString().Substring(0, 8);
    }
}