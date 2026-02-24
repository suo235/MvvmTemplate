using System.Windows.Controls;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for SetttingsTabView.xaml
/// </summary>
public partial class SettingsTabView : UserControl, IDisposable
{
    public SettingsTabView()
    {
        InitializeComponent();
    }

    public void Dispose()
    {
        (TabContent.DataContext as IDisposable)?.Dispose();
    }
}