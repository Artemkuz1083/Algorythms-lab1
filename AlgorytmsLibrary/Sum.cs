using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    public class Sum : IResercheable
    {
        // Запуск и суммирование
        public override void Run(int[] array, int value)
        {
            int sum = 0;
            foreach (int elem in array)
            {
                sum += elem;
            }
        }
        public Sum(int size, string name) : base(size, name)
        {
        }
    }
}
