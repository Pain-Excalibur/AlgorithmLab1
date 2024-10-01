using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms
{
    internal class Timsort : Algorithm
    {
        private const int RUN = 32; 

        protected override void DoAlg(object data)
        {
            uint[] array = (uint[])data;
            TimsortSort(array);
            Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
        }

        private void TimsortSort(uint[] array)
        {
            int n = array.Length;

RUN            for (int start = 0; start < n; start += RUN)
            {
                int end = Math.Min(start + RUN - 1, n - 1);
                Array.Sort(array, start, end - start + 1);
            }

            for (int size = RUN; size < n; size *= 2)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    if (mid < right)
                    {
                        Merge(array, left, mid, right);
                    }
                }
            }
        }

        private void Merge(uint[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            uint[] L = new uint[n1];
            uint[] R = new uint[n2];

            Array.Copy(array, left, L, 0, n1);
            Array.Copy(array, mid + 1, R, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    array[k++] = L[i++];
                }
                else
                {
                    array[k++] = R[j++];
                }
            }

            while (i < n1)
            {
                array[k++] = L[i++];
            }

            while (j < n2)
            {
                array[k++] = R[j++];
            }
        }
    }
}

