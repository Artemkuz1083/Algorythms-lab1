using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlgorytmsLibrary.Tools;

namespace AlgorytmsLibrary
{
    public class TimSort : IResercheable
    {
        public const int RUN = 32;

        // This function sorts array from left index to
        // to right index which is of size atmost RUN
        public static void insertionSort(int[] array,
            int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= left && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = temp;
            }
        }

        // merge function merges the sorted runs
        public static void merge(int[] array, int l,
            int m, int r)
        {
            // original array is broken in two parts
            // left and right array
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
                left[x] = array[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = array[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;

            // After comparing, we merge those two array
            // in larger sub array
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }

                k++;
            }

            // Copy remaining elements
            // of left, if any
            while (i < len1)
            {
                array[k] = left[i];
                k++;
                i++;
            }

            // Copy remaining element
            // of right, if any
            while (j < len2)
            {
                array[k] = right[j];
                k++;
                j++;
            }
        }

        // Iterative Timsort function to sort the
        // array[0...n-1] (similar to merge sort)
        public static void timSort(int[] array, int n)
        {
            // Sort individual subarrays of size RUN
            for (int i = 0; i < n; i += RUN)
                insertionSort(array, i,
                    Math.Min((i + RUN - 1), (n - 1)));

            // Start merging from size RUN (or 32).
            // It will merge
            // to form size 64, then
            // 128, 256 and so on ....
            for (int size = RUN;
                 size < n;
                 size = 2 * size)
            {
                // Pick starting point of
                // left sub array. We
                // are going to merge
                // arr[left..left+size-1]
                // and arr[left+size, left+2*size-1]
                // After every merge, we increase
                // left by 2*size
                for (int left = 0;
                     left < n;
                     left += 2 * size)
                {
                    // Find ending point of left sub array
                    // mid+1 is starting point of
                    // right sub array
                    int mid = left + size - 1;
                    int right = Math.Min((left +
                        2 * size - 1), (n - 1));

                    // Merge sub array arr[left.....mid] &
                    // arr[mid+1....right]
                    if (mid < right)
                        merge(array, left, mid, right);
                }
            }
        }

        public override void Run(int[] array, int value)
        {

            int n = array.Length;
            timSort(array, n);
        }
        public TimSort(int size, string name) : base(size, name)
        {
        }
    }
}
