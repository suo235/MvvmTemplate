using System.ComponentModel;
using System.Reactive.Linq;

using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;

namespace MvvmTemplate.ViewModels;

public class LoginWindowViewModel : ILoginWindowViewModel
{
    public ReactiveProperty<string> Username { get; private set; }

    public ReactiveProperty<string> Password { get; private set; }

    public ReactiveCommand LoginCommand { get; private set; }

    public User? LoginUser
    {
        get
        {
            return login_manager.LoginUser;   
        }
    }

    public event LoginEventHandler? LoginEvent;

#pragma warning disable CS0067
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067

    public LoginWindowViewModel(ILoginManager loginManager)
    {
        login_manager = loginManager;

        Username = new ReactiveProperty<string>().AddTo(disposable);
        Password = new ReactiveProperty<string>().AddTo(disposable);

        LoginCommand = Username.CombineLatest(Password, (t1, t2) =>
            !string.IsNullOrWhiteSpace(t1) && !string.IsNullOrWhiteSpace(t2))
            .ToReactiveCommand()
            .AddTo(disposable);
        LoginCommand.Subscribe(() =>
        {
            if(login_manager.Login(Username.Value, Password.Value))
            {
                LoginEvent?.Invoke(true);
            }
            else
            {
                LoginEvent?.Invoke(false);
            }
        });
    }

    public void Dispose()
    {
        disposable.Dispose();
    }

    private CompositeDisposable disposable { get; } = new CompositeDisposable();

    private ILoginManager login_manager;
}