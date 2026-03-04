using System.ComponentModel;

using Reactive.Bindings;

namespace MvvmTemplate.ViewModels;

public delegate void SaveEventHandler();

public interface IAccountSettingsPageViewModel : INotifyPropertyChanged, IDisposable
{
    public ReactiveProperty<string> Username { get; }

    public ReactiveProperty<string> Password { get; }

    public ReactiveProperty<string> ConfirmPassword { get; }

    public ReactiveCommand SaveCommand { get; }

    public event SaveEventHandler? SaveEvent;
}
