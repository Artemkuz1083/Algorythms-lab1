using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowAlgorythms
{
    public class RecPow : PowTest
    {
        private int stepsCount;
        public override long Run()
        {
            for (int i = 0; i < 2000; i++)
            {
                stepsCount = 0;
                RecAlgorithm(i);
                Steps.Add(new Steps(degree: i, stepNumber: stepsCount));
            }

            return 0;
        }

        public override string GetName()
        {
            return "RecPow";
        }

        private long RecAlgorithm(int degree)
        {
            if (degree == 0)
            {
                stepsCount++;
                return 1;
            }

            long res = RecAlgorithm(degree / 2);
            if (degree % 2 == 1)
            {
                stepsCount++;
                return res * res * 2;
            }

            stepsCount++;

            return res * res;
        }
    }
}
