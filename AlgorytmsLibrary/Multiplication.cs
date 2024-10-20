using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmsLibrary
{
    public class Multiplication : IResercheable
    {
        public Multiplication(int size, string name) : base(size, name)
        {

        }


        public override void Run(int[] array, int value)
        {
            int result = 1;

            for (int i = 0; i < array.Length; i++)
            {
                result *= array[i];
            }
        }

    }
}
