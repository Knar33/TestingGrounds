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
            TestClass1 tc1 = new TestClass1();
            bool b = tc1.tc2 == null;
        }

    }

    public class TestClass1
    {
        public TestClass2 tc2 { get; set; }
        public TestClass1()
        {

        }
    }

    public class TestClass2
    {
    }
}
