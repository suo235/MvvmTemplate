using System.Windows;
using System.Windows.Controls;

using MvvmTemplate.ViewModels;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for AccountSettingsPageView.xaml
/// </summary>
public partial class AccountSettingsPageView : UserControl, IDisposable
{
    public AccountSettingsPageView(IAccountSettingsPageViewModel viewModel)
    {
        InitializeComponent();

        viewModel.SaveEvent += () =>
        {
            Password.Clear();
            ConfirmPassword.Clear();
        };
        TabContent.DataContext = viewModel;
    }

    public void PasswordChangedHandler(Object sender, RoutedEventArgs args)
    {
        if(sender is PasswordBox passwordBox && TabContent.DataContext is IAccountSettingsPageViewModel viewModel)
        {
            viewModel.Password.Value = passwordBox.Password;
        }
    }

    public void ConfirmPasswordChangedHandler(Object sender, RoutedEventArgs args)
    {
        if(sender is PasswordBox passwordBox && TabContent.DataContext is IAccountSettingsPageViewModel viewModel)
        {
            viewModel.ConfirmPassword.Value = passwordBox.Password;
        }
    }

    public void Dispose()
    {
        (TabContent.DataContext as IDisposable)?.Dispose();
    }
}