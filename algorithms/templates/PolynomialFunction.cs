using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms
{
    internal class PolynomialFunction : Algorithm
    {
        protected override void DoAlg(object data)
        {
            (uint[] coefficients, double x) = ((uint[], double))data;

            double naiveResult = CalculateNaive(coefficients, x);
            double hornerResult = CalculateHorner(coefficients, x);

            Console.WriteLine($"Наивное вычисление P({x}): {naiveResult}");
            Console.WriteLine($"Метод Горнера P({x}): {hornerResult}");
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
