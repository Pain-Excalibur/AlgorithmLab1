using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using AlgoritmLab1.algorithms.templates;

namespace AlgoritmLab1.algorithms.powAlgs
{
    internal class QuickPow : PowAlg
    {
        protected override void DoAlg(object data)
        {
            uint[] d = (uint[])data;

            uint x = d[0];
            uint n = d[1];

            uint c = x;
            uint k = n;
            uint f;

            if (k % 2 == 1)
            {
                f = c;
            }
            else
            {
                f = 1;
            }
            while (true)
            {
                this.steps += 1;
                k = k / 2;
                c *= c;
                if (k % 2 == 1)
                {
                    f *= c;
                }

                if (k == 0)
                {
                    break;
                }


            }
        }
    }
}
