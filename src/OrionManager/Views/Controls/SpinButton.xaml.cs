using System.Windows;

namespace OrionManager.Views.Controls
{
    internal partial class SpinButton
    {
        public SpinButton()
        {
            InitializeComponent();

            Loaded += OnLoaded;
            ValueChanged += OnValueChanged;
            IncrementButton.Click += IncrementButtonOnClick;
            DecrementButton.Click += DecrementButtonOnClick;
        }

        public event DependencyPropertyChangedEventHandler ValueChanged;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            HandleCurrentValue();
        }

        private void OnValueChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            HandleCurrentValue();
        }

        private void HandleCurrentValue()
        {
            bool isIncrementEnabled;
            bool isDecrementEnabled;

            if (Value <= Min)
            {
                isIncrementEnabled = true;
                isDecrementEnabled = false;
            }
            else if (Value >= Max)
            {
                isIncrementEnabled = false;
                isDecrementEnabled = true;
            }
            else
            {
                isIncrementEnabled = true;
                isDecrementEnabled = true;
            }

            IncrementButton.IsEnabled = isIncrementEnabled;
            DecrementButton.IsEnabled = isDecrementEnabled;
        }

        private void DecrementButtonOnClick(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void IncrementButtonOnClick(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        #region Value dependency: int

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(int),
                typeof(SpinButton),
                new PropertyMetadata(default(int), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((SpinButton) sender).ValueChanged?.Invoke(sender, e);
        }

        public int Value
        {
            get => (int) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion

        #region Min dependency: int

        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register(
                nameof(Min),
                typeof(int),
                typeof(SpinButton),
                new PropertyMetadata(default(int)));

        public int Min
        {
            get => (int) GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }

        #endregion

        #region Max dependency: int

        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register(
                nameof(Max),
                typeof(int),
                typeof(SpinButton),
                new PropertyMetadata(default(int)));

        public int Max
        {
            get => (int) GetValue(MaxProperty);
            set => SetValue(MaxProperty, value);
        }

        #endregion
    }
}