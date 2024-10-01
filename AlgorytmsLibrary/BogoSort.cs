using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    public class BogoSort : IResercheable
    {
        public BogoSort(int size, string name) : base(size, name)
        {
        }
        public override void Run(int[] array, int value = 0)
        {
            BogoSortAlg(array);
        }
        private static void BogoSortAlg(int[] array)
        {
            Random random = new Random();

            // Продолжаем перемешивать массив, пока он не станет отсортированным
            while (!IsSorted(array))
            {
                Shuffle(array, random);
            }
        }

        // Метод для проверки, отсортирован ли массив
        private static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        private static void Shuffle(int[] array, Random random)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
