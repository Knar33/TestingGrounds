using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            File.Delete(@"C:\Users\USER_0137\Documents\FileThatDoesntExist.txt"); 
        }
    }
}
