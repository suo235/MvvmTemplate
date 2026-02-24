using System.Windows.Controls;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for AboutTabView.xaml
/// </summary>
public partial class AboutTabView : UserControl, IDisposable
{
    public AboutTabView()
    {
        InitializeComponent();
    }

    public void Dispose()
    {
        (TabContent.DataContext as IDisposable)?.Dispose();
    }
}