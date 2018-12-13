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
            string s = "I_like_cheese Love.";

            int exclamationLocation = 0;
            bool foundExclamation = false;
            for(int i = 0; i < s.Length; i++)
            {
                if (!foundExclamation && s[i] == '!')
                {
                    exclamationLocation = i;
                    foundExclamation = true;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < exclamationLocation; i++)
            {
                sb.Append(s[i]);
            }

            string output = s.Split('!')[0];

            Console.ReadLine();
        }
    }
}
