using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmsLibrary
{
    public class StrandSort : IResercheable
    {
        public StrandSort(int size, string name) : base(size, name)
        {
        }

        public override void Run(int[] array, int value = 0)
        {
            StrandSortAlg(array);
        }

        private static void StrandSortAlg(int[] array)
        {
            List<int> result = new List<int>();
            List<int> input = array.ToList();

            // Повторяем, пока исходный массив не будет пустым
            while (input.Count > 0)
            {
                List<int> sublist = new List<int>();
                sublist.Add(input[0]);  // Начинаем с первого элемента
                input.RemoveAt(0);

                // Проходим по оставшимся элементам, добавляя их в подсписок, если они больше предыдущего
                for (int i = 0; i < input.Count;)
                {
                    if (input[i] >= sublist.Last())
                    {
                        sublist.Add(input[i]);
                        input.RemoveAt(i);  // Удаляем элемент из исходного списка
                    }
                    else
                    {
                        i++;
                    }
                }

                // Сливаем результат с отсортированным подсписком
                result = Merge(result, sublist);
            }

            // Копируем отсортированные элементы обратно в исходный массив
            for (int i = 0; i < result.Count; i++)
            {
                array[i] = result[i];
            }
        }

        // Метод для слияния двух отсортированных списков
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> merged = new List<int>();
            int i = 0, j = 0;

            // Сливаем списки в отсортированном порядке
            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                {
                    merged.Add(left[i]);
                    i++;
                }
                else
                {
                    merged.Add(right[j]);
                    j++;
                }
            }

            // Добавляем оставшиеся элементы
            while (i < left.Count)
            {
                merged.Add(left[i]);
                i++;
            }
            while (j < right.Count)
            {
                merged.Add(right[j]);
                j++;
            }

            return merged;
        }
    }
}
