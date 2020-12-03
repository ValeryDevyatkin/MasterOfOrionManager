using System;
using OrionManager.DataModels;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;

namespace OrionManager.ExtensionMethods
{
    internal static class ModelCopyEx
    {
        public static void CopyFrom(this MainViewModel target, AppDataModel source)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // TODO: Copy fields here.

            target.IsGameStarted = source.IsGameStarted;
        }

        public static void CopyFrom(this GameDataViewModel target, GameDataModel source)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // TODO: Copy fields here.
        }
    }
}