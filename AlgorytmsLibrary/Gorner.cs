using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    public class Gorner : IResercheable
    {
        private int[] coefficients;

        public Gorner(int size, string name) : base(size, name)
        {
            coefficients = GenerateArray(size);
        }

        public override void Run(int[] array, int x = 0)
        {
            int n = coefficients.Length;
            long result = coefficients[0];

            for (int i = 1; i < n; i++)
            {
                result = result * x + coefficients[i];
            }
        }
    }
}
