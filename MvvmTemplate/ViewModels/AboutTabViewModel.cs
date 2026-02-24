using System.ComponentModel;

namespace MvvmTemplate.ViewModels;

public class AboutTabViewModel : INotifyPropertyChanged
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
    private string data_text = "About";

#pragma warning disable CS0067
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067
}