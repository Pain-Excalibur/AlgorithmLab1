using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmLab1.algorithms.templates;

namespace AlgoritmLab1.algorithms.powAlgs
{
    internal class RecPow : PowAlg
    {
        //итеративный алгоритм
        private uint Pow(uint x, uint n)
        {
            uint f;

            this.steps += 1;

            if (n == 0) 
            {
                f = 1;
                return f;
            }
            f = Pow(x, n / 2);
            if (n % 2 == 1)
            {
                f = f * f * x;
            }
            else
            {
                f = f * f;
            }
            return f;
        }

        protected override void DoAlg(object data)
        {
            uint[] d = (uint[])data;

            uint x = d[0];
            uint n = d[1];

            Pow(x, n);
            
        }
        
        
    }
}
