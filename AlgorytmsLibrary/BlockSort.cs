using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    public class BlockSort : IResercheable
    {
        public BlockSort(int size, string name) : base(size, name)
        {
        }

        public override void Run(int[] array, int value = 0)
        {
            BlockSortAlg(array);
        }

        private static void BlockSortAlg(int[] array)
        {
            int n = array.Length;

            // Шаг 1: Найти минимальный и максимальный элемент
            int min = array.Min();
            int max = array.Max();

            // Шаг 2: Создаем блоки
            int blockCount = (int)Math.Sqrt(n);  // Число блоков — это корень из длины массива
            List<int>[] blocks = new List<int>[blockCount];

            for (int i = 0; i < blockCount; i++)
            {
                blocks[i] = new List<int>();  // Инициализируем каждый блок
            }

            // Шаг 3: Распределяем элементы массива по блокам
            foreach (int num in array)
            {
                // Определяем, в какой блок попадет элемент
                int blockIndex = (num - min) * (blockCount - 1) / (max - min);
                blocks[blockIndex].Add(num);
            }

            // Шаг 4: Сортируем каждый блок
            for (int i = 0; i < blockCount; i++)
            {
                blocks[i].Sort();  // Сортировка каждого блока отдельно
            }

            // Шаг 5: Собираем отсортированные блоки обратно в исходный массив
            int index = 0;
            foreach (List<int> block in blocks)
            {
                foreach (int num in block)
                {
                    array[index++] = num;  // Перезаписываем элементы в исходный массив
                }
            }
        }
    }
}
