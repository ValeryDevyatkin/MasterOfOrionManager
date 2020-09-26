using System;
using OrionManager.DataModels;
using OrionManager.Interfaces;
using Senticode.Tools.WPF.MVVM.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class GameDataViewModel : ViewModelBase, ICopyFrom<GameDataModel>
    {
        public GameDataViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }

        public void CopyFrom(GameDataModel dataModel)
        {
            throw new NotImplementedException();
        }
    }
}