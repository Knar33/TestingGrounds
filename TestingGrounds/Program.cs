using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            string PostalCode = "60187";
            string trackingNumber = "9405511298370362193633";
            string BarCode = "420" + (new string(PostalCode.Take(5).ToArray())) + trackingNumber;

        }
    }
}
