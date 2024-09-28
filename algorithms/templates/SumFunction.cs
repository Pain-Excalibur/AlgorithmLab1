using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms
{
    internal class SumFunction : Algorithm
    {
        protected override void DoAlg(object data)
        {
            uint[] vector = (uint[])data;
            int result = CalculateSum(vector);
            Console.WriteLine($"Сумма элементов: {result}");
        }

        public int CalculateSum(uint[] vector)
        {
            int sum = 0;
            foreach (var value in vector)
            {
                sum += (int)value;
            }
            return sum;
        }
    }
}
