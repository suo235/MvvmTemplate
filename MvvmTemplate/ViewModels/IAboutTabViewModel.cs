using System.ComponentModel;

namespace MvvmTemplate.ViewModels;

public interface IAboutTabViewModel : INotifyPropertyChanged
{
    string DataText { get; set; }
}
