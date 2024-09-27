using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowAlgorythms
{
    public class Pow : PowTest
    {
        public override long Run()
        {
            long res = 1;
            for (int i = 0; i < 2000; i++)
            {
                int count = 0;
                res = 1;
                int degree = i;
                for (int j = 0; j < degree; j++)
                {
                    res *= Number;
                    count++;

                }
                Steps.Add(new Steps(degree: degree, stepNumber: count));
            }

            return res;
        }

        public override string GetName()
        {
            return "Pow";
        }
    }
}
