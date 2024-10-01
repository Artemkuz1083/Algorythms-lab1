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
using AlgorytmsLibrary;
using System.Threading;
using PowAlgorythms;

namespace Algorythms
{
    /// <summary>
    /// Логика взаимодействия для NoPowWindow.xaml
    /// </summary>
    public partial class NoPowWindow : Window
    {
        public NoPowWindow()
        {
            InitializeComponent();
        }

        private IResercheable GetSelectedAlgorithm()
        {
            switch (SelectAlgorythm.SelectedIndex)
            {
                case 0: return new Linal(2000, "BubbleSort");
                case 1: return new Sum(50000, "Summ");
                case 2: return new Multiplication(20000, "Multiplication");
                case 3: return new Gorner0(10000, "Gorner0");
                case 4: return new Gorner(10000, "Gorner");
                case 5: return new QuickSort(5000, "QuickSort");
                case 6: return new TimSort(20000, "TimSort");
                case 7: return new BubbleSort(2000, "BubbleSort");
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IResercheable algorithm = GetSelectedAlgorithm();

            // Создание данных для графика
            var values = AlgorytmsLibrary.Tools.Export(algorithm);

            // Создание графика
            var plotModel = new PlotModel { Title = "My Graph" };
            var linearAxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Count(n)" };
            var linearAxis2 = new LinearAxis { Position = AxisPosition.Left, Title = "Avg time" };

            plotModel.Axes.Add(linearAxis);
            plotModel.Axes.Add(linearAxis2);

            var lineSeries = new LineSeries { ItemsSource = values };
            plotModel.Series.Add(lineSeries);

            // Привязка данных к графику
            Plot.Model = plotModel;
        }
    }
}
