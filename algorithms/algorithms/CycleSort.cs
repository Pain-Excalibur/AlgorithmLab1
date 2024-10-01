using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmLab1.algorithms.templates;

namespace AlgoritmLab1.algorithms.algorithms
{
    internal class CycleSort : Algorithm
    {
        protected override void DoAlg(object data)
        {
            uint[] arr = (uint[])data;
            int n = arr.Length;

            for (int cycleStart = 0; cycleStart <= n - 2; cycleStart++)
            {
                uint item = arr[cycleStart];

                // Find the position where we put the item
                int pos = cycleStart;
                for (int i = cycleStart + 1; i < n; i++)
                    if (arr[i] < item)
                        pos++;

                // If the item is already in the correct position
                if (pos == cycleStart)
                    continue;

                while (item == arr[pos])
                    pos += 1;

                if (pos != cycleStart)
                {
                    uint temp = item;
                    item = arr[pos];
                    arr[pos] = temp;
                }

                // Rotate the rest of the cycle
                while (pos != cycleStart)
                {
                    pos = cycleStart;

                    // Find the position where we put the element
                    for (int i = cycleStart + 1; i < n; i++)
                        if (arr[i] < item)
                            pos += 1;

                    while (item == arr[pos])
                        pos += 1;

                    if (item != arr[pos])
                    {
                        uint temp = item;
                        item = arr[pos];
                        arr[pos] = temp;
                    }
                }
            }
        }
    }
}
