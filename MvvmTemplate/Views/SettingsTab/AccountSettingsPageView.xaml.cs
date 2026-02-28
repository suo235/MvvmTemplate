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

        TabContent.DataContext = viewModel;
    }

    public void Dispose()
    {
        (TabContent.DataContext as IDisposable)?.Dispose();
    }
}