using System.ComponentModel;

namespace MvvmTemplate;

public delegate void LoginEventHandler(bool result);

public interface ILoginWindowViewModel : INotifyPropertyChanged, IDisposable
{
    User? LoginUser{ get; }

    event LoginEventHandler? LoginEvent;
}