using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowAlgorythms
{
    public class QuickPow1 : PowTest
    {
        public override long Run()
        {
            long res = 1;
            for (int i = 0; i < 2000; i++)
            {
                int count = 0;
                int number = Number;
                res = 1;
                int degree = i;

                while (degree != 0)
                {
                    if (degree % 2 == 0)
                    {
                        number *= number;
                        degree /= 2;
                        count += 2;
                    }
                    else
                    {
                        res *= number;
                        degree--;
                        count += 2;

                    }
                }
                Steps.Add(new Steps(degree: i, stepNumber: count));

            }


            return res;
        }

        public override string GetName()
        {
            return "QuickPow1";
        }
    }
}
