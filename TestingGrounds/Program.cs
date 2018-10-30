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
            collectionContainer container = new collectionContainer();
            container.Collection = new List<int>() { 1, 2, 3 };
            foreach (int thisInt in container.Collection)
            {
                thisInt = 1l;
            }

            List<int> otherCollection = new List<int>() { 1, 2, 3 };
            foreach (int thisInt in container.Collection)
            {
                thisInt = 1l;
            }
        }
    }

    public class collectionContainer
    {
        public IReadOnlyCollection<ComplexObject> Collection { get; set; }
    }

    public class ComplexObject
    {
        public int ComplexProperty { get; set; }
    }
}
