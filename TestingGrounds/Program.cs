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
            process(null);
        }

        public static void process(Foo foo)
        {

        }
    }

    public class Foo
    {
        public string Bar { get; set; }
    }
}
