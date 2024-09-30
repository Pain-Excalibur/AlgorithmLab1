using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmLab1.algorithms.templates;


namespace AlgoritmLab1.algorithms.powAlgs
{
    internal class NaivePow : PowAlg
    {
        protected override void DoAlg(object data)
        {
            uint[] d = (uint[])data;

            uint x = d[0];
            uint n = d[1];

            int f = 1;
            int k = 0;
            while (k < n)
            {
                this.steps += 1;
                f *= k;
                k++;
            }

        }
    }
}
