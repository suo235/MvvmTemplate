using System.Windows;
using MvvmTemplate.ViewModels;

namespace MvvmTemplate.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IMainWindowViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;

        Closed += (s, e) =>
        {
            (SettingsTab.Content as IDisposable)?.Dispose();
            (StatisticsTab.Content as IDisposable)?.Dispose();
            (AboutTab as IDisposable)?.Dispose();
        };
    }
}