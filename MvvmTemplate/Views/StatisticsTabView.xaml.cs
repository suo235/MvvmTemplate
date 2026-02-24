using System.Windows.Controls;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for StatisticsTabView.xaml
/// </summary>
public partial class StatisticsTabView : UserControl, IDisposable
{
    public StatisticsTabView()
    {
        InitializeComponent();
    }

    public void Dispose()
    {
        (TabContent.DataContext as IDisposable)?.Dispose();
    }
}