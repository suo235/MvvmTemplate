using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using MvvmTemplate.Views;
using MvvmTemplate.ViewModels;
using MvvmTemplate.Models;

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

        MainWindow = service_provider.GetRequiredService<MainWindow>();

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

        services.AddScoped<LoginWindow>();
        services.AddScoped<MainWindow>();
    }

    private readonly ServiceProvider service_provider;
}

