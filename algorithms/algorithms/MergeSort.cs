using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AlgoritmLab1.algorithms.templates;

namespace AlgoritmLab1.algorithms.algorithms
{
    internal class MergeSort : Algorithm
    {
        private void Merge(uint[] arr, int l, int m, int r)
        {   
            int n1 = m - l + 1;
            int n2 = r - m;
            
            uint[] L = new uint[n1];
            uint[] R = new uint[n2];
            
            Array.Copy(arr, l, L, 0, n1);
            Array.Copy(arr, m + 1, R, 0, n2);

            
            int i = 0, j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        private void Sort(uint[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                Sort(arr, l, m);
                Sort(arr, m + 1, r);
                
                Merge(arr, l, m, r);
            }
        }

        protected override void DoAlg(object data)
        {
            uint[] arr = (uint[])data;
            int n = arr.Length;
            MessageBox.Show(arr.ToString());
            Sort(arr, 0, n-1);
            MessageBox.Show(arr.ToString());
        }
    }
}
