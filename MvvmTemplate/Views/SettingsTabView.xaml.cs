using System.Windows.Controls;

using MvvmTemplate.ViewModels;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for SetttingsTabView.xaml
/// </summary>
public partial class SettingsTabView : UserControl, IDisposable
{
    public SettingsTabView(ISettingsTabViewModel viewModel)
    {
        InitializeComponent();

        TabContent.DataContext = viewModel;
    }

    public void Dispose()
    {
        (TabContent.DataContext as IDisposable)?.Dispose();
    }
}