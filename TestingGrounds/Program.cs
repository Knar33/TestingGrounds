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
                        //plug in points[p].Item1 and points[p].Item2 as your x and y values
                        if (Math.Pow(points[p].Item1, 2) + Math.Pow(points[p].Item2, 2) <= 1)
                        {
                            pointsInQuadrant++;
                        }
                    }
                    //check your ratio of pointsInQuanrant/randomPoints
                    double nEstimated = 4.0 * (double)pointsInQuadrant / (double)randomPoints;
                    double error = nEstimated / Math.PI;
                    Console.WriteLine(string.Format("{0} | {1} | {2} | {3}", randomPoints, pointsInQuadrant, nEstimated, error));
                    //print line
                }
                
                Console.ReadKey();
            }
        }
    }
}
