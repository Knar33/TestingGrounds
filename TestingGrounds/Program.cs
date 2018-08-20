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

            decimal? c = a.WeightInPounds + b.WeightInPounds;
        }

        public class Summer
        {
            public decimal? WeightInPounds { get; set; }
           
        }
    }
}
