using System.Windows.Controls;

using MvvmTemplate.ViewModels;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for StatisticsTabView.xaml
/// </summary>
public partial class StatisticsTabView : UserControl, IDisposable
{
    public StatisticsTabView(IStatisticsTabViewModel viewModel)
    {
        InitializeComponent();

        TabContent.DataContext = viewModel;
    }

    public void Dispose()
    {
        (TabContent.DataContext as IDisposable)?.Dispose();
    }
}