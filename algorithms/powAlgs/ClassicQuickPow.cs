using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms.powAlgs
{
    internal class ClassicQuickPow : PowAlg
    {
        protected override void DoAlg(object data)
        {
            uint[] dt = (uint[])data;
            int c =(int) dt[0];
            int f = 1;
            int k = (int)dt[1];

            while (true)
            {
                if (k != 0)
                {
                    this.steps += 1;
                    if (k % 2 == 0)
                    {
                        c = c * c;
                        k = k / 2;
                    }
                    else
                    {
                        f = f * c;
                        k = k - 1;
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
