using OrionManager.Common.Enums;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class ContinueGameCommand : SyncCommandBase
    {
        private readonly IUnityContainer _container;

        public ContinueGameCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            _container.Resolve<MainViewModel>().Region = UiRegions.Playing;
            _container.Resolve<GameDataViewModel>().IsOpenedAndReady = true;
        }
    }
}