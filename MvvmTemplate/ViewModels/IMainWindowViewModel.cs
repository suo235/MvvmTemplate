using System.ComponentModel;

namespace MvvmTemplate.ViewModels;

public interface IMainWindowViewModel : INotifyPropertyChanged
{
    public User? LoginUser{ get; set; }
}