using System.ComponentModel;

using ScottPlot.WPF;

namespace MvvmTemplate.ViewModels;

public interface IStatisticsTabViewModel : INotifyPropertyChanged, IDisposable
{
    string DataText{ get; set; }

    WpfPlot Plot { get; }
}