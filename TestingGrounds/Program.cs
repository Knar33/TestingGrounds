using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            Summer a = new Summer { WeightInPounds = null };
            Summer b = new Summer { WeightInPounds = 26 };

            List<Summer> c = new List<Summer>();
            c.Add(a);
            c.Add(b);

            decimal? d = c.Sum(x => x.WeightInPounds);

            decimal? e = a.WeightInPounds + b.WeightInPounds;

            bool f = d == 0;
        }

        public class Summer
        {
            public decimal? WeightInPounds { get; set; }
        }
    }
}
