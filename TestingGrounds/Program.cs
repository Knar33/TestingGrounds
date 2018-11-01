using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestingGrounds.RateService;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal? num = 0.0600m;
            float finalNum = (float)(Math.Max(num * 16 ?? 0, 1.0m));
            Console.WriteLine(finalNum);
            
            num = 0.2340m;
            finalNum = (float)(Math.Max(num * 16 ?? 0, 1.0m));
            Console.WriteLine(finalNum);
            Console.ReadLine();
        }

    }
}
