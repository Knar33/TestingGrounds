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
            List<string> videoGames = new List<string> { };
            bool running = true;

            while (running)
            {
                Console.Write("Enter a game, or type exit to quit: ");
                string gameName = Console.ReadLine();

                if (gameName == "exit")
                {
                    running = false;
                    break;
                }

                videoGames.Add(gameName);

                Console.WriteLine("Games List: ");
                foreach (string game in videoGames)
                {
                    Console.WriteLine(game);
                }
                Console.WriteLine();
            }
        }
    }
}
