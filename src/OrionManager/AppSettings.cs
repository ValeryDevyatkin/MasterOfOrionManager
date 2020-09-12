using Senticode.Tools.WPF.Core.Base;
using Unity;

namespace OrionManager
{
    internal class AppSettings : AppSettingsBase
    {
        public AppSettings(IUnityContainer container) : base(container)
        {
        }

        #region IsGameContinuationAvailable: bool

        public bool IsGameContinuationAvailable
        {
            get => _isGameContinuationAvailable;
            private set => SetProperty(ref _isGameContinuationAvailable, value);
        }

        private bool _isGameContinuationAvailable;

        #endregion
    }
}