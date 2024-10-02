using System.Collections.Generic;

namespace PowAlgorythms
{
    public class RecPow : IPowAlgorithm
    {
        public List<(int, int)> Steps { get; private set; } = new List<(int, int)>();

        public void Run(int maxDegree)
        {
            int number = 2;
            for (int degree = 1; degree <= maxDegree; degree++)
            {
                int stepCount = 0;
                int result = RecPowRecursive(number, degree, ref stepCount);
                Steps.Add((degree, stepCount));
            }
        }

        private int RecPowRecursive(int baseNum, int exp, ref int stepCount)
        {
            stepCount++;
            if (exp == 0)
                return 1;
            return baseNum * RecPowRecursive(baseNum, exp - 1, ref stepCount);
        }

        public string GetName()
        {
            return "RecPow";
        }
    }
}
