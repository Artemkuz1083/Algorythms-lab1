using AlgorytmsLibrary;
using LiveCharts.SeriesAlgorithms;
using System;
using System.Linq;

namespace PowAlgorythms
{
    public class HeapSort : IPowAlgorithm
    {
        public HeapSort()
        {
            TestArray = Tools.GenerateArray(100); // Генерация массива для теста, например, на 100 элементов
        }

        public override void Run()
        {
            HeapSortAlgorithm(TestArray);
        }

        public override double GetResult()
        {
            return TestArray.Average(); // Возвращает среднее значение массива после сортировки
        }

        private void HeapSortAlgorithm(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        private void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                Heapify(array, n, largest);
            }
        }
    }
}
