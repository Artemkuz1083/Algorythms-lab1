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

        public static void merge(int[] array, int l,
            int m, int r)
        {

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


            while (i < len1)
            {
                array[k] = left[i];
                k++;
                i++;
            }

            while (j < len2)
            {
                array[k] = right[j];
                k++;
                j++;
            }
        }

        public static void timSort(int[] array, int n)
        {
            for (int i = 0; i < n; i += RUN)
                insertionSort(array, i,
                    Math.Min((i + RUN - 1), (n - 1)));

            for (int size = RUN;
                 size < n;
                 size = 2 * size)
            {
                
                for (int left = 0;
                     left < n;
                     left += 2 * size)
                {

                    int mid = left + size - 1;
                    int right = Math.Min((left +
                        2 * size - 1), (n - 1));

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
