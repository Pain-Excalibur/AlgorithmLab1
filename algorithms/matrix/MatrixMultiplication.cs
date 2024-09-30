using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using AlgoritmLab1.algorithms.templates;

namespace AlgoritmLab1.algorithms.matrix
{
    internal class MatrixMultiplication : templates.Matrix
    {
        protected override void DoAlg(object data)
        {
            uint[,] matrix = (uint[,])data;
            //implementation for resust matrix is missed
            uint someRes = 0;
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        someRes += matrix[i, k] * matrix[k, j];
                    }
                    someRes = 0;
                }
            }
        }
    }
}
