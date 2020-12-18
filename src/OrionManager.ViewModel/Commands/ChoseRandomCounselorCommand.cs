using System;
using System.Linq;
using BAJIEPA.Tools.Helpers;
using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class ChoseRandomCounselorCommand : SyncCommandBase
    {
        private readonly IUnityContainer _container;

        public ChoseRandomCounselorCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            if (!(parameter is PlayerViewModel player))
            {
                throw new ArgumentException(nameof(parameter));
            }

            player.Counselor = _container.Resolve<GameDataViewModel>().CounselorMap.Values
                                         .Where(x => x.Value != Counselors.None)
                                         .Where(x => x.IsEnabled)
                                         .ToArray()
                                         .GetRandomItem(player.Counselor);
        }
    }
}