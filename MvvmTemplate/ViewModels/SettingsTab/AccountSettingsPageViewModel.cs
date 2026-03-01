using System.ComponentModel;

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

#pragma warning disable CS0067
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067

    public AccountSettingsPageViewModel(ILoginManager loginManager)
    {
        login_manager = loginManager;

        Username = new ReactiveProperty<string>().AddTo(disposable);
        Password = new ReactiveProperty<string>().AddTo(disposable);
        ConfirmPassword = new ReactiveProperty<string>().AddTo(disposable);
    }

    public void Dispose()
    {
        disposable.Dispose();
    }

    private CompositeDisposable disposable { get; } = new CompositeDisposable();

    private ILoginManager login_manager;
}