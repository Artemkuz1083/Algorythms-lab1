using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PowAlgorythms;

namespace Algorythms
{
    /// <summary>
    /// Логика взаимодействия для PowWindow.xaml
    /// </summary>
    public partial class PowWindow : Window
    {
        public PowWindow()
        {
            InitializeComponent();

            IPowAlgorithm algorithm = GetSelectedAlgorithm();

            // Создание данных для графика
            var values = new List<DataPoint> { new DataPoint(0, 1), new DataPoint(1, 2), new DataPoint(2, 3), new DataPoint(3, 4), new DataPoint(4, 5) };

            // Создание графика
            var plotModel = new PlotModel { Title = "Pow" };
            var linearAxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Numbers" };
            var linearAxis2 = new LinearAxis { Position = AxisPosition.Left, Title = "Steps" };

            plotModel.Axes.Add(linearAxis);
            plotModel.Axes.Add(linearAxis2);

            var lineSeries = new LineSeries { ItemsSource = values };
            plotModel.Series.Add(lineSeries);

            // Привязка данных к графику
            Plot.Model = plotModel;
        }

        private IPowAlgorithm GetSelectedAlgorithm()
        {
            switch (SelectAlgorythm.SelectedIndex)
            {
                case 0: return new Pow();
                case 1: return new RecPow();
                case 2: return new QuickPow();
                case 3: return new QuickPow1();
            }
            return null;
        }
    }
}
