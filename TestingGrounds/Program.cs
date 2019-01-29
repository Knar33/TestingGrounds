using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestingGrounds.RateService;
using System.Runtime.CompilerServices;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            var createy = new CreateyClass(0);
            Console.ReadLine();
        }
    }

    public class CreateyClass
    {
        public CreateyClass(int recursion)
        {
            Console.WriteLine(recursion);
            if (recursion < 10)
            {
                var recursiveCreatey = new CreateyClass(recursion + 1);
            }
        }
    }
}
