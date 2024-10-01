using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgoritmLab1.algorithms.algorithms
{
    internal class CountingSort : Algorithm
    {
        protected override void DoAlg(object data)
        {
            uint[] array = (uint[])data;

            if (array.Length == 0)
            {
                return;
            }

            
            uint max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            
            uint[] countArray = new uint[max + 1];

            for (int i = 0; i < array.Length; i++)
            {
                countArray[array[i]]++;
            }

            for (int i = 1; i < countArray.Length; i++)
            {
                countArray[i] += countArray[i - 1];
            }

            uint[] outputArray = new uint[array.Length];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                outputArray[countArray[array[i]] - 1] = array[i];
                countArray[array[i]]--;
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = outputArray[i];
            }
        }
    }
}
