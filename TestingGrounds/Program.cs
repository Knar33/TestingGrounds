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
            Console.WriteLine(stringyEnum.STRINGY1.ToString());
            Console.ReadLine();
        }
    }

    public enum stringyEnum
    {
        STRINGY1,
        STRINGY2
    }
}
