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
            List<IColor> colors = new List<IColor>();
            colors.Add(new Red());
            colors.Add(new Blue());

            var redColor = (Red)colors.FirstOrDefault(x => x.GetType().Equals(typeof(Red)));
        }

    }

    public class Red : IColor
    {
        public string name = "Red";
    }

    public class Blue : IColor
    {
        public string name = "Blue";
    }

    public interface IColor
    {

    }
}
