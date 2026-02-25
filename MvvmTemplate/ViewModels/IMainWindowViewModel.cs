using System.ComponentModel;

using MvvmTemplate.Models;

namespace MvvmTemplate.ViewModels;

public interface IMainWindowViewModel : INotifyPropertyChanged
{
    public User? LoginUser{ get; set; }
}