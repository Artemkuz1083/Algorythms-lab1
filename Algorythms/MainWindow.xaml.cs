
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Generic;
using System.Windows;

namespace Algorythms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Создание данных для графика
            var values = new List<DataPoint> { new DataPoint(0, 1), new DataPoint(1, 2), new DataPoint(2, 3), new DataPoint(3, 4), new DataPoint(4, 5) };

            // Создание графика
            var plotModel = new PlotModel { Title = "My Graph" };
            var linearAxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "X-Axis" };
            var linearAxis2 = new LinearAxis { Position = AxisPosition.Left, Title = "Y-Axis" };
            plotModel.Axes.Add(linearAxis);
            plotModel.Axes.Add(linearAxis2);
            var lineSeries = new LineSeries { ItemsSource = values };
            plotModel.Series.Add(lineSeries);

            // Привязка данных к графику
            Plot.Model = plotModel;
        }
    }
}
