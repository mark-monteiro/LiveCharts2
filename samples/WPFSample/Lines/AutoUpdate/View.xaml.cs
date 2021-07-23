using System;
using System.Threading.Tasks;
using System.Windows.Controls;

using LiveChartsCore.SkiaSharpView.WPF;

using ViewModelsSamples.Lines.AutoUpdate;

namespace WPFSample.Lines.AutoUpdate
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : UserControl
    {
        private bool? isStreaming = false;

        private readonly CartesianChart chart = new CartesianChart();

        public View()
        {
            InitializeComponent();

            _ = chart.SetBinding(CartesianChart.SeriesProperty, nameof(ViewModel.Series));
            ChartWrapper.Content = chart;
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (ViewModel)DataContext;
            isStreaming = isStreaming is null ? true : !isStreaming;

            while (isStreaming.Value)
            {
                vm.RemoveFirstItem();
                vm.AddItem();
                await Task.Delay(1000);
            }
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            ChartWrapper.Content = ChartWrapper.Content == null ? chart : null;
        }
    }
}
