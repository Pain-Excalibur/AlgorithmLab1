using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms.algorithms
{
    internal class NaivePolinomial : Algorithm
    {
        protected override void DoAlg(object data)
        {
            uint[] coefficients = (uint[])data;
            double x = 1.5;

            double naiveResult = CalculateNaive(coefficients, x);
        }

        public double CalculateNaive(uint[] coefficients, double x)
        {
            double result = 0;
            for (int k = 0; k < coefficients.Length; k++)
            {
                result += coefficients[k] * Math.Pow(x, k);
            }
            return result;
        }
    }
}
