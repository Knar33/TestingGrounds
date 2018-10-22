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
            {
                int N = 10000000;

                //print header of table
                Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} |", "N".ToString().PadRight(20, ' '), "Ninside".ToString().PadRight(20, ' '), "PIestimated".ToString().PadRight(20, ' '), "Error".ToString().PadRight(20, ' ')));

                //generate a List<Tuple<double, double>>
                Random random = new Random();
                List<Tuple<double, double>> points = new List<Tuple<double, double>>();
                for (int i = 0; i < N; i++)
                {
                    points.Add(new Tuple<double, double>(random.NextDouble(), random.NextDouble()));
                }

                //for each power of 10 between 10 and N
                for (int i = 1; i <= Math.Log10(N); i++)
                {
                    int pointsInQuadrant = 0;
                    int randomPoints = Convert.ToInt32(Math.Pow(10.0, (double)i));
                    for (int p = 0; p < randomPoints; p++)
                    {
                        double x = points[p].Item1;
                        double y = points[p].Item2;
                        //plug in points[p].Item1 and points[p].Item2 as your x and y values
                        if (Math.Pow(x, 2) + Math.Pow(y, 2) <= 1)
                        {
                            pointsInQuadrant++;
                        }
                    }
                    //check your ratio of pointsInQuanrant/randomPoints
                    double nEstimated = 4.0 * pointsInQuadrant / randomPoints;
                    double error = nEstimated / Math.PI;

                    //print line
                    Console.WriteLine(string.Format("|{0}|{1}|{2}|{3}|", "".PadRight(22, '-'), "".PadRight(22, '-'), "".PadRight(22, '-'), "".PadRight(22, '-')));
                    Console.WriteLine(string.Format("| {0} | {1} | {2} | {3} |", randomPoints.ToString().PadRight(20, ' '), pointsInQuadrant.ToString().PadRight(20, ' '), nEstimated.ToString().PadRight(20, ' '), error.ToString().PadRight(20, ' ')));
                }

                //print footer of table
                Console.WriteLine("".PadRight(93, '-'));

                Console.ReadKey();
            }
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
