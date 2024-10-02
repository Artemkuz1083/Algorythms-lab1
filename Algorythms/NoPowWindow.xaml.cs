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
using MathNet;
using MathNet.Numerics;

namespace Algorythms
{
    /// <summary>
    /// Логика взаимодействия для NoPowWindow.xaml
    /// </summary>
    public partial class NoPowWindow : System.Windows.Window
    {
        public NoPowWindow()
        {
            InitializeComponent();
        }

        private IResercheable GetSelectedAlgorithm()
        {
            switch (SelectAlgorythm.SelectedIndex)
            {
                case 0: return new Linal(2000, "Linal");
                case 1: return new Sum(5000, "Summ");
                case 2: return new Multiplication(20000, "Multiplication");
                case 3: return new Gorner(10000, "Gorner");
                case 4: return new Gorner0(10000, "Direct");
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
            // Получаем алгоритм
            IResercheable algorithm = GetSelectedAlgorithm();

            // Получаем значения minN и maxN
            if (int.TryParse(MinNInput.Text, out int minN) && int.TryParse(MaxNInput.Text, out int maxN))
            {
                if (minN > 0 && maxN > minN)
                {

                    // Генерация данных для графика
                    var values = AlgorytmsLibrary.Tools.Export(algorithm, minN, maxN);
                    var plotModel = new PlotModel { Title = algorithm.Name };
                    var count = values.Count;

                    var lineSeries = new LineSeries
                    {
                        ItemsSource = values,
                        MarkerType = MarkerType.Circle,
                        Title = algorithm.Name,
                        Color = OxyColors.Red,
                        MarkerFill = OxyColors.DarkRed
                    };


                    // Данные для апроксимации
                    double[] xData = values.Select((t, i) => (double)(minN + i)).ToArray();
                    double[] yData = (double[])values.Select(t => t.Y).ToArray();

                    // Вычисляем коэффициенты полинома 3-й степени
                    double[] polynomialCoefficients = GetPolynomialApproximation(xData, yData, 3);

                    // Создаем FunctionSeries для апроксимации
                    FunctionSeries approximationSeries = new FunctionSeries(
                        x => polynomialCoefficients[0] + polynomialCoefficients[1] * x +
                             polynomialCoefficients[2] * x * x + polynomialCoefficients[3] * x * x * x,
                        xData.Min(), xData.Max(), 0.1,
                        $"{algorithm.Name} (Апроксимация)"
                    );
                    approximationSeries.Color = OxyColors.Black;

                    // Добавляем графики на PlotModel
                    plotModel.Series.Add(lineSeries);
                    plotModel.Series.Add(approximationSeries);

                    // Создание графика                    
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
                        Title = "Avg time(Tick /100)",
                        MajorGridlineStyle = LineStyle.Solid,
                        MinorGridlineStyle = LineStyle.Dot
                    };

                    plotModel.Axes.Add(linearAxis);
                    plotModel.Axes.Add(linearAxis2);

              
                    //plotModel.Series.Add(lineSeries);

                    // Привязка данных к графику
                    Plot.Model = plotModel;
                }
                else
                {
                    MessageBox.Show("Invalid input: minN should be > 0 and maxN should be > minN.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid integer values for minN and maxN.");
            }

        }

        private double[] GetPolynomialApproximation(double[] xData, double[] yData, int degree)
        {
            return Fit.Polynomial(xData, yData, degree);
        }
    }
}