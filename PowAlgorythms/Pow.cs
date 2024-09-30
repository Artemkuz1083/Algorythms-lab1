using System.Collections.Generic;

namespace PowAlgorythms
{
    public class Pow : IPowAlgorithm
    {
        public List<(int, int)> Steps { get; private set; } = new List<(int, int)>();

        public void Run()
        {
            int number = 2;
            for (int degree = 1; degree <= 10; degree++)
            {
                int result = 1;
                int stepCount = 0;
                for (int i = 0; i < degree; i++)
                {
                    result *= number;
                    stepCount++;
                }
                Steps.Add((degree, stepCount));
            }
        }

        public string GetName()
        {
            return "Pow";
        }
    }
}
