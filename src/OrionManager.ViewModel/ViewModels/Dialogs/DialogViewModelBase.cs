using System;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModel.ViewModels.Dialogs
{
    public abstract class DialogViewModelBase : ViewModelBase, IDisposable
    {
        protected DialogViewModelBase(IUnityContainer container) : base(container)
        {
        }

        public void Dispose()
        {
        }
    }
}