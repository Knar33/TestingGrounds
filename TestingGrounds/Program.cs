using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestingGrounds.RateService;
using System.Runtime.CompilerServices;
using System.Net.Http;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            var otherThings = ReturnTwoThings();
            string a = things.a;
            int b = things.b;
        }

        public static (string a, int b) ReturnTwoThings()
        {
            return ("a string", 12345);
        }
    }
}
