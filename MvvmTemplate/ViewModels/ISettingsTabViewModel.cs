using System.ComponentModel;

namespace MvvmTemplate.ViewModels;

public interface ISettingsTabViewModel : INotifyPropertyChanged, IDisposable
{
    string DataText{ get; set; }
}