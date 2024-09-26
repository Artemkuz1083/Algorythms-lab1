using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    public class QuickSort : IResercheable
    {
        // принимает массив и возвращает отсортированный массив 
        public static int[] Calculate(int[] vector)
        {
            if (vector.Length <= 1) return vector;
            var randomNum = vector[new Random().Next(0, vector.Length)];

            int bigCount = 0;
            int lowCount = 0;
            int equalCount = 0;

            foreach (var element in vector)
            {
                if (element > randomNum)
                    bigCount++;
                else if (element < randomNum)
                    lowCount++;
                else
                    equalCount++;
            }

            int[] bigElements = new int[bigCount];
            int[] lowElements = new int[lowCount];
            int[] equalElements = new int[equalCount];

            int lowindex = 0; //Для перекладки элемента в нужное место массива
            int bigindex = 0; //
            int equalindex = 0; //

            for (int i = 0; i < vector.Length; i++)
            {
                var element = vector[i];
                if (element > randomNum)
                    bigElements[bigindex++] = element;
                else if (element < randomNum)
                    lowElements[lowindex++] = element;
                else
                    equalElements[equalindex++] = element;
            }

            Calculate(lowElements);
            Calculate(bigElements);

            for (int i = 0; i < vector.Length; i++)
            {
                if (i < lowElements.Length)
                    vector[i] = lowElements[i];
                else if (i - lowElements.Length < equalElements.Length)
                    vector[i] = equalElements[i - lowElements.Length];
                else
                    vector[i] = bigElements[i - lowElements.Length - equalElements.Length];
            }
            return vector; // возвращение отсортированного массива
        }

        public QuickSort(int size, string name) : base(size, name)
        {
        }
        // Запуск
        public override void Run(int[] array, int value = 0)
        {
            Calculate(array);
        }
    }
}
