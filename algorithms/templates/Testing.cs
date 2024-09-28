using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmLab1.algorithms.templates
{
    internal abstract class Testing
    {
        protected abstract void DoAlg(object data);

        protected abstract object GetData(uint n);

        public virtual double[] StartTesting(uint n, uint m)
        {
            //loop тестов

            double[,] allTests = new double[m, n];
            Stopwatch stopwatch = new Stopwatch();
            for (uint precision = 0; precision < m; precision++)
                for (uint dataSize = 1; dataSize <= n; dataSize++)
                {
                    //do test/alg/writedata here

                    //получить данные
                    object data = GetData(dataSize);
                    
                    //сделать алгоритм
                    stopwatch.Restart();//засекаю

                    DoAlg(data);

                    stopwatch.Stop();

                    //записать результат
                    allTests[precision, dataSize] = stopwatch.ElapsedTicks / 10000000.0d;

                }

            //расчет среднего времени

            double[] timeApprox = new double[n];
            for (int dataSize = 0; dataSize < n; dataSize++) //actually, data size -1 потому что массивы с нуля считают
            {
                for (int j = 0; j < m; j++)
                    timeApprox[dataSize] += allTests[j, dataSize]; //суммируем значения для одного колличества данных

                timeApprox[dataSize] /= m; //и делим на их колличество
            }

            //вывод массивва среднего времени для каждого размера данных
            return timeApprox;
        }
    }
}
