using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Kit> kits = new List<Kit>();

            // deserialize JSON directly from a file
            using (StreamReader file = new StreamReader(@"C:\Users\xxx\Documents\Kits.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                kits = (List<Kit>)serializer.Deserialize(file, typeof(List<Kit>));
            }
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
