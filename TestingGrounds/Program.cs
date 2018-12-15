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
            Random random = new Random();
            Console.Write("Pick 1 for Rock, 2 for Paper, 3 for scissors: ");
            while (true)
            {
                Console.WriteLine((new int[] { 1, -2 }).Contains((int.Parse(Console.ReadLine()) - 1) - random.Next(0, 2)) ? "You Win!" : "You Lose!");
            }
        }
    }
}
