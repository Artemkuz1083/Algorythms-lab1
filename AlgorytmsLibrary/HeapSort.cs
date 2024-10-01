using System;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    public class HeapSort : IResercheable
    {
        public HeapSort(int size, string name) : base(size, name)
        {
        }

        public override void Run(int[] array, int value = 0)
        {
            HeapSortAlg(array);
        }

        private static void HeapSortAlg(int[] array)
        {
            int n = array.Length;

            // Построение кучи (heap)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            // Извлечение элементов из кучи один за другим
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень (максимальный элемент) в конец
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // Восстанавливаем свойства кучи на оставшейся части массива
                Heapify(array, i, 0);
            }
        }

        // Метод для восстановления кучи
        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i;  // Инициализация наибольшего как корня
            int left = 2 * i + 1;  // Левый дочерний элемент
            int right = 2 * i + 2; // Правый дочерний элемент

            // Если левый дочерний элемент больше корня
            if (left < n && array[left] > array[largest])
                largest = left;

            // Если правый дочерний элемент больше, чем наибольший элемент на данный момент
            if (right < n && array[right] > array[largest])
                largest = right;

            // Если наибольший элемент не корень
            if (largest != i)
            {
                // Меняем местами корень и наибольший элемент
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                // Рекурсивно восстанавливаем кучу
                Heapify(array, n, largest);
            }
        }
    }


}
