using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowAlgorythms
{
    public abstract class PowTest
    {
        public int Number { get; set; } = 3;
        public List<Steps> Steps { get; set; } = new List<Steps>();

        public abstract long Run();

        public abstract string GetName();
    }
}
