using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            orderDetails.Add(new OrderDetail { WeightInPounds = null });
            orderDetails.Add(new OrderDetail { WeightInPounds = null });
            orderDetails.Add(new OrderDetail { WeightInPounds = null });

            Package package = new Package(orderDetails);

            foreach (PackageDetail packageDetail in package.PackageDetails)
            {
                packageDetail.WeightInPounds = 1m;
            }

            if (package.WeightInPounds != null && package.WeightInPounds != 0)
            {
                Console.WriteLine("Not Null or 0");
            }
            else
            {
                Console.WriteLine("Null or 0");
            }

            Console.ReadLine();
        }
    }

    public class Package
    {
        public Package(List<OrderDetail> orderDetails)
        {
            PackageDetails = new List<PackageDetail>();

            foreach (OrderDetail orderDetail in orderDetails)
            {
                PackageDetails.Add(new PackageDetail(orderDetail));
            }

            WeightInPounds = PackageDetails.Sum(x => x.WeightInPounds);
        }

        public List<PackageDetail> PackageDetails { get; set; }

        public decimal? WeightInPounds { get; set; }
    }

    public class PackageDetail
    {
        public PackageDetail(OrderDetail orderDetail)
        {
        }
        public decimal? WeightInPounds { get; set; }
    }

    public class OrderDetail
    {
        public decimal? WeightInPounds { get; set; }
    }
}
