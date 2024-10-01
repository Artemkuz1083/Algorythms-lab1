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
                case 0: return new Linal(500, "Linal");
                case 1: return new Sum(50000, "Summ");
                case 2: return new Multiplication(20000, "Multiplication");
                case 3: return new Gorner0(10000, "Direct");
                case 4: return new Gorner(10000, "Gorner");
                case 5: return new QuickSort(5000, "QuickSort");
                case 6: return new TimSort(20000, "TimSort");
                case 7: return new BubbleSort(2000, "BubbleSort");
                case 8: return new Matr(1000, "Matrix");
                case 9: return new BlockSort(2000, "BlockSort");
                case 10: return new StrandSort(2000, "StrandSort");
                case 11: return new BogoSort(10, "BogoSort");
                case 12: return new HeapSort(2000, "HeapSort");
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IResercheable algorithm = GetSelectedAlgorithm();

            // Создание данных для графика
            var values = AlgorytmsLibrary.Tools.Export(algorithm);

            // Создание графика
            var plotModel = new PlotModel { Title = algorithm.Name};
            var linearAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Count(n)",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            var linearAxis2 = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Avg time",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            plotModel.Axes.Add(linearAxis);
            plotModel.Axes.Add(linearAxis2);

            var lineSeries = new LineSeries { ItemsSource = values, MarkerType = MarkerType.Circle, Title = algorithm.Name, Color = OxyColors.Red,  MarkerFill = OxyColors.DarkRed };
            plotModel.Series.Add(lineSeries);

            // Привязка данных к графику
            Plot.Model = plotModel;
        }
    }
}
