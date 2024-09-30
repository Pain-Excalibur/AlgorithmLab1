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

        public int GetStepsCount()
        {
            return this.steps;
        }

        protected override object GetData(uint n)
        {
            //тут я возвращаю массив из двух элементов в порядке: [0] - число для возведения в степень [1] - степень
            return new uint[2] { (uint)rand.Next(100), n };
        }
    }
}