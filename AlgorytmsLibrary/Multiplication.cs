using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmsLibrary
{
    internal class Multiplication : IResercheable
    {
        public Multiplication(int size, string name) : base(size, name)
        {

        }


        public override void Run(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= array[i];
            }
        }

    }
}
