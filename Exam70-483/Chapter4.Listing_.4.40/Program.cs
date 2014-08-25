using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4.Listing_._4._40
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.MyServiceClient client = new ServiceReference1.MyServiceClient();
            var result = client.DoWork("Hej", "Test");
        }
    }
}
