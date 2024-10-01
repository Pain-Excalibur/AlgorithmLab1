using AlgoritmLab1.algorithms.templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms.algorithms
{
    internal class ProductFunction : Algorithm
    {
        protected override void DoAlg(object data)
        {
            uint[] vector = (uint[])data;
            int result = CalculateProduct(vector);
        }

        public int CalculateProduct(uint[] vector)
        {
            int product = 1;
            foreach (var value in vector)
            {
                product *= (int)value;
            }
            return product;
        }
    }
}
