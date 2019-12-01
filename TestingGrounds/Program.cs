using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestingGrounds.RateService;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Reflection;
using System.ComponentModel;

namespace TestingGrounds
{
    public enum myEnum
    {
        [Description("String 1")]
        Val1 = 0,
        [Description("String 1")]
        Val2 = 1
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            myEnum enummy = myEnum.Val1;
            string val = enummy.ToDescriptionString();
            Console.ReadLine();
        }
    }

    public static class Classy
    {
        public static string ToDescriptionString(this myEnum enummy)
        {
            FieldInfo info = enummy.GetType().GetField(enummy.ToString());
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes?[0].Description ?? enummy.ToString();
        }
    }
}
