using System;
using OrionManager.ViewModels;
using Senticode.Wpf;
using Unity;

namespace OrionManager.ExtensionMethods
{
    internal static class ConfigurationViewModelEx
    {
        public static void CopyFrom(this GameConfigurationViewModel target, GameConfigurationViewModel source)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (ReferenceEquals(target, source))
            {
                throw new ArgumentException(nameof(source));
            }

            // TODO: Copy fields here.

            target.Name = source.Name;
            target.SaveTime = source.SaveTime;
        }

        public static GameConfigurationViewModel Clone(this GameConfigurationViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var viewModel = ServiceLocator.Container.Resolve<GameConfigurationViewModel>();

            viewModel.CopyFrom(item);

            return viewModel;
        }

        public static bool HasDifference(this GameConfigurationViewModel item1, GameConfigurationViewModel item2)
        {
            if (item1 == null)
            {
                throw new ArgumentNullException(nameof(item1));
            }

            if (item2 == null)
            {
                throw new ArgumentNullException(nameof(item2));
            }

            if (ReferenceEquals(item1, item2))
            {
                throw new ArgumentException(nameof(item2));
            }

            // TODO: Compare fields here.

            if (item1.Name != item2.Name)
            {
                return true;
            }

            return false;
        }
    }
}