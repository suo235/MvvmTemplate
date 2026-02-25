using System.ComponentModel;

using MvvmTemplate.Models;

namespace MvvmTemplate.ViewModels;

public delegate void LoginEventHandler(bool result);

public interface ILoginWindowViewModel : INotifyPropertyChanged, IDisposable
{
    User? LoginUser{ get; }

    event LoginEventHandler? LoginEvent;
}