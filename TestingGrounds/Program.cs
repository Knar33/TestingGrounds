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
            int wageAnswer;
            if (!int.TryParse(Console.ReadLine(), out wageAnswer))
            {
                Console.WriteLine("you messed up");
            }
            Console.ReadLine();
        }
    }
}
