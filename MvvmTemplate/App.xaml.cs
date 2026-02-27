using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using MvvmTemplate.Views;
using MvvmTemplate.ViewModels;
using MvvmTemplate.Models;
using System.Runtime.CompilerServices;

namespace MvvmTemplate;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        service_provider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = service_provider.GetRequiredService<MainWindow>();
        mainWindow.SettingsTab.Content = service_provider.GetRequiredService<SettingsTabView>();
        mainWindow.StatisticsTab.Content = service_provider.GetRequiredService<StatisticsTabView>();
        MainWindow = mainWindow;

        var loginWindow = service_provider.GetRequiredService<LoginWindow>();
        loginWindow.ShowDialog();
    
        if(loginWindow.DialogResult == false)
        {
            Shutdown();
            return;
        }
        else
        {
            var loginWindowViewModel = service_provider.GetRequiredService<ILoginWindowViewModel>();
            var mainWindowViewModel = service_provider.GetRequiredService<IMainWindowViewModel>();
            mainWindowViewModel.LoginUser = loginWindowViewModel.LoginUser;

            MainWindow.Show();
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ILoginManager, LoginManager>();

        services.AddScoped<ILoginWindowViewModel, LoginWindowViewModel>();
        services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
        services.AddScoped<ISettingsTabViewModel, SettingsTabViewModel>();
        services.AddScoped<IStatisticsTabViewModel, StatisticsTabViewModel>();

        services.AddScoped<LoginWindow>();
        services.AddScoped<MainWindow>();
        services.AddScoped<SettingsTabView>();
        services.AddScoped<StatisticsTabView>();
    }

    private readonly ServiceProvider service_provider;
}

