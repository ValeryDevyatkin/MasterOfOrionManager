using Senticode.Wpf.Base;

namespace OrionManager.ViewModels
{
    internal class DisablingItemViewModel<T> : ObservableObject

    {
        public DisablingItemViewModel(T item)
        {
            Value = item;
            IsEnabled = true;
        }

        public T Value { get; }

        #region IsEnabled: bool

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private bool _isEnabled;

        #endregion
    }
}