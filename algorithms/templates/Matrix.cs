using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms.templates
{
    internal abstract class Matrix : Testing
    {
        static Random rand = new Random();

        protected override object GetData(uint n)
        {
            uint[,] vector = new uint[n,n];
            for (uint i = 0; i < n; i++)
                for (uint j = 0; j < n; j++)
                    vector[i,j] = (uint)rand.Next();
            return vector;
        }
    }
}
