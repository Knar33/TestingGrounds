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
            
        }
    }

    public class Kit
    {
        public Kit()
        {
            Components = new List<Component>();
        }

        public string SKU { get; set; }
        public List<Component> Components { get; set; }
    }

    public class Component
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public string HSCode { get; set; }
    }
}
