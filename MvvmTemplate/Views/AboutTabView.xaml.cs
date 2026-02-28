using System.Windows.Controls;

using MvvmTemplate.ViewModels;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for AboutTabView.xaml
/// </summary>
public partial class AboutTabView : UserControl, IDisposable
{
    public AboutTabView(IAboutTabViewModel viewModel)
    {
        InitializeComponent();

        TabContent.DataContext = viewModel;
    }

    public void Dispose()
    {
        (TabContent.DataContext as IDisposable)?.Dispose();
    }
}