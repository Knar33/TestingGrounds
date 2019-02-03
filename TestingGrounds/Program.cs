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
            for(int i = 0; i < 257; i++)
            {
                var packedByte = GeneratePackedField(i);
                Console.WriteLine("{0} : {1}", i, Convert.ToString(packedByte, 2).PadLeft(8, '0'));
            }
            Console.ReadLine();
        }

        private static byte GeneratePackedField(int colorCount)
        {
            int packedFieldValue = 16;
            if (colorCount > 0)
            {
                packedFieldValue += 128;
            }

            int globalColorTableSize = 0;
            for (int p = 1; p < 8; p++)
            {
                if (colorCount > Math.Pow(2, p))
                {
                    globalColorTableSize++;
                }
            }
            packedFieldValue += globalColorTableSize;
            return Convert.ToByte(packedFieldValue);
        }
    }
}
