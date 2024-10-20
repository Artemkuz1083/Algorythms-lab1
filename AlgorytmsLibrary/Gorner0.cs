using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    public class Gorner0 : IResercheable
    {
        static double Direct(int[] array)
        {
            double x = 1.5;
            double result = 0;

            for (int k = 0; k < array.Length; k++)
            {
                result += array[k] * Math.Pow(x, k - 1);
            }

            return result;
        }

        public Gorner0(int size, string name) : base(size, name)
        {
        }

        public override void Run(int[] array, int value = 0)
        {
            Direct(array);
        }
    }
}
