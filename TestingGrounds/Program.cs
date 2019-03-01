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
using System.Net.Http;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            string a = "D29";
            string b = a.Substring(1, a.Length - 1);

            a = "D290";
            b = a.Substring(1, a.Length - 1);
        }
    }
}
