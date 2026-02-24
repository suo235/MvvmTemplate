using System.ComponentModel;

namespace MvvmTemplate.ViewModels;

public class SettingsTabViewModel : INotifyPropertyChanged, IDisposable
{
    public string DataText 
    {
        get
        {
            return data_text;
        }
        set
        {
            data_text = value;
        }
    }
    private string data_text = "Settings";

#pragma warning disable CS0067
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067

    public SettingsTabViewModel()
    {
        
    }

    public void Dispose()
    {
        
    }
}