﻿using System;
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
using System.Net.Http;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = new List<int>()
            {
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,1, 1, 1, 1, 1,
                2, 2, 2, 2, 2, 2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,2, 2, 2, 2, 2,
                3, 3, 3, 3, 3, 3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,3, 3, 3, 3, 3,
                4, 4, 4, 4, 4, 4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,4, 4, 4, 4, 4,
                5, 5, 5, 5, 5
            };

            List<int> outputs = new List<int>();
            for (int i = 0; i <= Math.Floor((decimal)(numList.Count() / 100)); i++)
            {
                int output = 0;
                var requestChunk = numList.Skip(i * 100).Take(100).ToArray();
                foreach (var num in requestChunk)
                {
                    output += num;
                }
                outputs.Add(output);
            }
        }
    }
}
