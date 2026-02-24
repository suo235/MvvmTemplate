using System.ComponentModel;
using ScottPlot.WPF;

namespace MvvmTemplate.ViewModels;

public class StatisticsTabViewModel : INotifyPropertyChanged, IDisposable
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
    private string data_text = "Statistics";

    public WpfPlot Plot { get; } = new WpfPlot();

#pragma warning disable CS0067
    public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067

    public StatisticsTabViewModel()
    {
        double[] dataX = { 1, 2, 3, 4, 5 };
        double[] dataY = { 1, 4, 9, 16, 25 };
        Plot.Plot.Add.Scatter(dataX, dataY);
        Plot.Refresh();
    }

    public void Dispose()
    {
        
    }
}