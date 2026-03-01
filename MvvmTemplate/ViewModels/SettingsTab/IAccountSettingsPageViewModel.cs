using System.ComponentModel;

using Reactive.Bindings;

namespace MvvmTemplate.ViewModels;

public interface IAccountSettingsPageViewModel : INotifyPropertyChanged, IDisposable
{
    public ReactiveProperty<string> Username { get; }

    public ReactiveProperty<string> Password { get; }

    public ReactiveProperty<string> ConfirmPassword { get; }
}
