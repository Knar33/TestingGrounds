using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            string dateDelivered = DateTimeOffset.ParseExact("20180829044930", "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString();
        }
    }
}
