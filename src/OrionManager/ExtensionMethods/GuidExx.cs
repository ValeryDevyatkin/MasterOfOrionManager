using System;

namespace OrionManager.ExtensionMethods
{
    internal static class GuidExx
    {
        public static string GetHead(this Guid guid) => guid.ToString().Substring(0, 8);
    }
}