using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms
{
    internal class QuickSort : Algorithm
    {
        protected override void DoAlg(object data)
        {
            int[] array = (int[])data;
            Sort(array, 0, array.Length - 1);
            Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
        }

        public void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);

                Sort(array, low, pi - 1);
                Sort(array, pi + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high]; 
            int i = (low - 1); 

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;

                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            return i + 1;
        }
    }
}
