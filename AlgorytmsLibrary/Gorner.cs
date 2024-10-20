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

        public Gorner(int size, string name) : base(size, name)
        {

        }

        public override void Run(int[] array, int x = 0)
        {
            int [] coefficients = array;

            double result = coefficients[0];

            for (int i = 1; i < coefficients.Length; i++)
            {
                result += coefficients[i] * Math.Pow(x, i);
            }
        }
    }
}
