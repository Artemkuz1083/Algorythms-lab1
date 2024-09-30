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
                List<(int, int)> steps = Tools.Export(algorithm);
                Console.WriteLine($"Algorithm: {algorithm.GetName()}");
                foreach (var step in steps)
                {
                    Console.WriteLine($"Degree: {step.Item1}, Steps: {step.Item2}");
                }
            }
        }
    }

    //экспорт шагов
    class Tools
    {
        public static List<(int, int)> Export(IPowAlgorithm algorithm)
        {
            algorithm.Run();
            return algorithm.Steps;
        }
    }
}
