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
            TimeSpan span = new TimeSpan(0, 0, 240);
            Console.Write(span.ToString());
            Console.ReadLine();
        }
    }
}
