using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoritmLab1.algorithms.templates;

namespace AlgoritmLab1.algorithms
{
    internal class ConstantFunction : Algorithm
    {
        protected override void DoAlg(object data)
        {
            uint[] vector = (uint[])data;
            int result = CalculateFunction(vector);
            Console.WriteLine($"Результат: {result}");
        }

        public int CalculateFunction(uint[] vector)
        {
            return 1; 
        }
    }
}
