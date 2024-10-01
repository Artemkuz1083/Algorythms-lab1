using OxyPlot;
using System;
using System.Collections.Generic;

namespace PowAlgorythms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IPowAlgorithm> algorithmList = new List<IPowAlgorithm>()
            {
                new Pow(),
                new QuickPow(),
                new QuickPow1(),
                new RecPow()
            };

            foreach (IPowAlgorithm algorithm in algorithmList)
            {
                List<DataPoint> steps = Tools.Export(algorithm);               
            }
        }
    }

    //экспорт шагов
    public class Tools
    {
        public static List<DataPoint> Export(IPowAlgorithm algorithm)
        {
            algorithm.Run();
            var steps = algorithm.Steps;
            var points = new List<DataPoint>();
            foreach (var step in steps)
            {
                points.Add(new DataPoint(step.Item2, step.Item1));
            }
            return points;
        }
    }
}
