using System.Windows;
using System.Windows.Controls;

using MvvmTemplate.ViewModels;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    public LoginWindow(ILoginWindowViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;

        Closed += (s, e) =>
        {
            viewModel.LoginEvent -= LoginExecuted;
            (DataContext as IDisposable)?.Dispose();
        };

        viewModel.LoginEvent += LoginExecuted;
    }

    public void PasswordChangedHandler(Object sender, RoutedEventArgs args)
    {
        if(sender is PasswordBox passwordBox && DataContext is LoginWindowViewModel viewModel)
        {
            viewModel.Password.Value = passwordBox.Password;
        }
    }

    private void LoginExecuted(bool result)
    {
        DialogResult = result;
    }
}