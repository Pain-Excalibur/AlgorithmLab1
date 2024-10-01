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
            int n = matrix.GetLength(0);
            uint[,] resultMatrix = new uint[n, n];
            uint sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        sum += matrix[i, k] * matrix[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }
        }
    }
}
