using OrionManager.Common.Enums;
using OrionManager.ViewModel.ExtensionMethods;
using OrionManager.ViewModel.ViewModels;
using OrionManager.ViewModel.ViewModels.Main;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.Commands
{
    internal class FinishGameCommand : SyncCommandBase
    {
        private readonly IUnityContainer _container;

        public FinishGameCommand(IUnityContainer container)
        {
            _container = container.RegisterInstance(this);
        }

        protected override void ExecuteExternal(object parameter)
        {
            _container.Resolve<GameDataViewModel>().Reset();
            _container.Resolve<MainViewModel>().IsGameStarted = false;
            _container.Resolve<MainViewModel>().Region = UiRegions.Start;
        }
    }
}