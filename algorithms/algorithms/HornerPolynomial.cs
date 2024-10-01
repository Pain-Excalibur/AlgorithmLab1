using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms.algorithms
{
    internal class HornerPolynomial : Algorithm
    {
        protected override void DoAlg(object data)
        {
            uint[] coefficients = (uint[])data;
            double x = 1.5;

            double hornerResult = CalculateHorner(coefficients, x);
        }

        public double CalculateHorner(uint[] coefficients, double x)
        {
            double result = coefficients[0];
            for (int k = 1; k < coefficients.Length; k++)
            {
                result = result * x + coefficients[k]; // Метод Горнера
            }
            return result;
        }
    }
}
