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
            int a = calculatePositions(255, 7);
        }

        public static int calculatePositions(int colorCount, int colorTableSize)
        {
            int outputCount = 0;
            for (int i = 0; i < colorCount; i++)
            {
                outputCount += 3;
            }
            int colorsRequired = (int)Math.Pow(2, (colorTableSize + 1));
            for (int i = colorCount; i < colorsRequired; i++)
            {
                outputCount += 3;
            }
            return outputCount;
        }
    }
}
