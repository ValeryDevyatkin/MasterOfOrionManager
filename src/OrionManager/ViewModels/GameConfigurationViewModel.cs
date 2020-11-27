using System;
using OrionManager.DataModels;
using OrionManager.Interfaces;
using Senticode.Wpf.Base;
using Unity;

namespace OrionManager.ViewModels
{
    internal class GameConfigurationViewModel : ViewModelBase, ICopyFrom<GameConfigurationDataModel>
    {
        public GameConfigurationViewModel(IUnityContainer container) : base(container)
        {
        }

        public Guid Id { get; private set; }

        public void CopyFrom(GameConfigurationDataModel dataModel)
        {
            Id = dataModel.Id;
            Name = dataModel.Name;
            SaveTime = dataModel.SaveTime;
        }

        #region SaveTime: DateTime

        public DateTime SaveTime
        {
            get => _saveTime;
            set => SetProperty(ref _saveTime, value);
        }

        private DateTime _saveTime;

        #endregion

        #region Name: string

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _name;

        #endregion
    }
}