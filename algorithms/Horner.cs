﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmLab1.algorithms.templates;

namespace AlgoritmLab1.algorithms
{
    internal class Horner : Algorithm
    {
        protected override void DoAlg(long[] vector)
        {
            double polynomial = 0;
            for (int i = vector.Length - 1; i > 0; i--)
            {
                polynomial *= 1.5;
                polynomial = vector[i - 1] + polynomial;
            }
        }
    }
}