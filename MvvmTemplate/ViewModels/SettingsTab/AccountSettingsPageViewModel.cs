using System.ComponentModel;
using System.Reactive.Linq;

using MvvmTemplate.Models;

using Reactive.Bindings;
using System.Reactive.Disposables;
using Reactive.Bindings.Extensions;

namespace MvvmTemplate.ViewModels;

public class AccountSettingsPageViewModel : IAccountSettingsPageViewModel
{
    public ReactiveProperty<string> Username { get; private set; }

    public ReactiveProperty<string> Password { get; private set; }

    public ReactiveProperty<string> ConfirmPassword { get; private set; }

    public ReactiveCommand SaveCommand { get; private set; }

    public event SaveEventHandler? SaveEvent;

#pragma warning disable CS0067
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067

    public AccountSettingsPageViewModel(ILoginManager loginManager)
    {
        login_manager = loginManager;

        Username = new ReactiveProperty<string>().AddTo(disposable);
        Password = new ReactiveProperty<string>().AddTo(disposable);
        ConfirmPassword = new ReactiveProperty<string>().AddTo(disposable);

        SaveCommand = Username.CombineLatest(Password, ConfirmPassword, (t1, t2, t3) =>
            !string.IsNullOrWhiteSpace(t1) && !string.IsNullOrWhiteSpace(t2) && !string.IsNullOrWhiteSpace(t3)
            && t2.Equals(t3, StringComparison.Ordinal))
            .ToReactiveCommand()
            .AddTo(disposable);

        SaveCommand.Subscribe(() =>
        {
            try
            {
                login_manager.UpdateUser(Username.Value, Password.Value);
            }
            catch(Exception)
            {
                
            }
            finally
            {
                SaveEvent?.Invoke();
            }
        });

        Username.Value = login_manager.LoginUser?.Name ?? string.Empty;
    }

    public void Dispose()
    {
        disposable.Dispose();
    }

    private CompositeDisposable disposable { get; } = new CompositeDisposable();

    private ILoginManager login_manager;
}