using System.ComponentModel;

using MvvmTemplate.Models;

namespace MvvmTemplate.ViewModels;

public class MainWindowViewModel : IMainWindowViewModel
{
    public User? LoginUser
    {
        get => login_user;
        set
        {
            login_user = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoginUser)));
        }
    }
    private User? login_user = null;

#pragma warning disable CS0067
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067

    public MainWindowViewModel(ILoginManager loginManager)
    {
        login_manager = loginManager;
    }

    private ILoginManager login_manager;
}