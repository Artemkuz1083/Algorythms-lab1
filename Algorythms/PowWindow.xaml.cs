using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PowAlgorythms;
using MathNet;
using MathNet.Numerics;

namespace Algorythms
{
    public partial class PowWindow : System.Windows.Window
    {
        public PowWindow()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IPowAlgorithm algorithm = GetSelectedAlgorithm();

            // Получаем введенную степень
            int maxDegree;
            if (!int.TryParse(DegreeInput.Text, out maxDegree))
            {
                MessageBox.Show("Введите корректное целое число для степени.");
                return;
            }

            // Создание данных для графика с введенной степенью
            var values = PowAlgorythms.Tools.Export(algorithm, maxDegree);
            var plotModel = new PlotModel { Title = algorithm.GetName() };
            var count = values.Count;

            var lineSeries = new LineSeries
            {
                ItemsSource = values,
                MarkerType = MarkerType.Circle,
                Title = "Pow",
                Color = OxyColors.Red,
                MarkerFill = OxyColors.DarkRed
            };


            // Данные для апроксимации
            double[] xData = values.Select((t, i) => (double)(1 + i)).ToArray();
            double[] yData = (double[])values.Select(t => t.Y).ToArray();

            // Вычисляем коэффициенты полинома 3-й степени
            double[] polynomialCoefficients = GetPolynomialApproximation(xData, yData, 3);

            // Создаем FunctionSeries для апроксимации
            FunctionSeries approximationSeries = new FunctionSeries(
                x => polynomialCoefficients[0] + polynomialCoefficients[1] * x +
                        polynomialCoefficients[2] * x * x + polynomialCoefficients[3] * x * x * x,
                xData.Min(), xData.Max(), 0.1,
                $"Pow (Апроксимация)"
                );
            approximationSeries.Color = OxyColors.Black;

            plotModel.Series.Add(lineSeries);
            plotModel.Series.Add(approximationSeries);

            // Создание графика
            var linearAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Degree",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            var linearAxis2 = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Steps",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            plotModel.Axes.Add(linearAxis);
            plotModel.Axes.Add(linearAxis2);
           

            // Привязка данных к графику
            Plot.Model = plotModel;
        }

        private double[] GetPolynomialApproximation(double[] xData, double[] yData, int degree)
        {
            return Fit.Polynomial(xData, yData, degree);
        }
    }
}