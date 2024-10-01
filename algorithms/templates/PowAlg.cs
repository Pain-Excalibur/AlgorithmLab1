using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms.templates
{
    internal abstract class PowAlg : Testing
    {
        static Random rand = new Random();

        protected int steps = 0;

        public override double[] GetResults(uint n, uint m)
        {
            double[] stepsResult = new double[n];

            for (uint dataSize = 0; dataSize < n; dataSize++)
            {
                this.steps = 0;

                for (uint i = 0; i < m; i++)
                {
                    this.steps = 0;

                    DoAlg(GetData(dataSize + 1));

                    stepsResult[dataSize] += this.steps;
                }

                stepsResult[dataSize] /= m;
            }

            return stepsResult;
        }

        protected override object GetData(uint n)
        {
            //тут я возвращаю массив из двух элементов в порядке: [0] - число для возведения в степень [1] - степень
            return new uint[2] { (uint)rand.Next(100), n };
        }
    }
}