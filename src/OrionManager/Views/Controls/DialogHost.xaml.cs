using System;
using System.Windows;
using System.Windows.Input;
using OrionManager.ViewModel.Interfaces;
using OrionManager.ViewModel.ViewModels.Dialogs;
using Senticode.Wpf;
using Unity;

namespace OrionManager.Views.Controls
{
    public partial class DialogHost : IDialogHost
    {
        private readonly IUnityContainer _container;
        private DialogViewModelBase _dialogViewModel;

        public DialogHost()
        {
            _container = ServiceLocator.Container;

            if (_container.IsRegistered<IDialogHost>())
            {
                throw new NotSupportedException();
            }

            _container.RegisterInstance<IDialogHost>(this);
            Visibility = Visibility.Collapsed;
            InitializeComponent();
            Shadow.MouseLeftButtonUp += ShadowOnMouseLeftButtonUp;
        }

        public void ShowDialog<T>(T viewModel)
            where T : DialogViewModelBase
        {
            _dialogViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            ContentControl.DataContext = _dialogViewModel;
            ContentControl.Content = _container.Resolve<IDialogFor<T>>();
            Visibility = Visibility.Visible;
        }

        public void ShowDialog<T>() where T : DialogViewModelBase
        {
            ShowDialog(_container.Resolve<T>());
        }

        public void CloseDialog()
        {
            Visibility = Visibility.Collapsed;
            ContentControl.Content = null;
            ContentControl.DataContext = null;
            _dialogViewModel?.Dispose();
            _dialogViewModel = null;
        }

        private void ShadowOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CloseDialog();
        }
    }
}