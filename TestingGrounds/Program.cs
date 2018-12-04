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
            List<string> strings = new List<string>();
            strings.Add(null);
            strings.Add(null);
            strings.Add("a");
            strings.Add("b");

            var distinctStrings = strings.Distinct();
            foreach(string distinctString in distinctStrings)
            {
                Console.WriteLine(distinctString);
            }
            Console.ReadLine();
        }
    }
}
