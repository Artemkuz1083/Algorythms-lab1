using OxyPlot;
using System;
using System.Collections.Generic;

namespace PowAlgorythms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxDegree = 1000; // Указываем максимальную степень

            List<IPowAlgorithm> algorithmList = new List<IPowAlgorithm>()
            {
                new Pow(),
                new QuickPow(),
                new QuickPow1(),
                new RecPow()
            };

            foreach (IPowAlgorithm algorithm in algorithmList)
            {
                List<DataPoint> steps = Tools.Export(algorithm, maxDegree);  // Передаем maxDegree
            }
        }
    }

    //экспорт шагов
    public class Tools
    {

        public static List<DataPoint> Export(IPowAlgorithm algorithm, int maxDegree)
        {
            algorithm.Run(maxDegree);  // Передаем максимальную степень в алгоритм
            var steps = algorithm.Steps;
            var points = new List<DataPoint>();
            foreach (var step in steps)
            {
                points.Add(new DataPoint(step.Item1, step.Item2));  // Строим график по шагам и результатам
            }
            return points;
        }
    }
}