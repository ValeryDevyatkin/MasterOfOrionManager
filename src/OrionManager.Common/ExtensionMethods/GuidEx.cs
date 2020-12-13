using System;

namespace OrionManager.Common.ExtensionMethods
{
    public static class GuidEx
    {
        public static string GetHead(this Guid guid) => guid.ToString().Substring(0, 8);
    }
}