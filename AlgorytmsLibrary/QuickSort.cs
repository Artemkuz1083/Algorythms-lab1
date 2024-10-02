using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorytmsLibrary
{
    public class QuickSort : IResercheable
    {
        public QuickSort(int size, string name) : base(size, name) { }

        public override void Run(int[] array, int value = 0)
        {
            QuickSortAlgorithm(array, 0, array.Length - 1);
        }

        private void QuickSortAlgorithm(int[] array, int left, int right)
        {
            if (left >= right) return;

            int pivotIndex = Partition(array, left, right);
            QuickSortAlgorithm(array, left, pivotIndex - 1);
            QuickSortAlgorithm(array, pivotIndex + 1, right);
        }

        private int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    Swap(array, i, j);
                    i++;
                }
            }

            Swap(array, i, right);
            return i;
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}