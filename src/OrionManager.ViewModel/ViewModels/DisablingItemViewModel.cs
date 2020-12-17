using Senticode.Wpf.Base;

namespace OrionManager.ViewModel.ViewModels
{
    public abstract class DisablingItemViewModelBase : ObservableObject
    {
        protected DisablingItemViewModelBase()
        {
            IsEnabled = true;
        }

        #region IsEnabled: bool

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private bool _isEnabled;

        #endregion
    }

    public class DisablingItemViewModel<T> : DisablingItemViewModelBase

    {
        public DisablingItemViewModel(T item)
        {
            Value = item;
        }

        public T Value { get; }
    }
}