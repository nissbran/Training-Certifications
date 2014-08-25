using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ Using join 
            string[] popularProductNames = { "A", "B" };
            var products = new List<Product>() {
                new Product() { Name = "A"},
                new Product() { Name = "A"},
                new Product() { Name = "B"},
                new Product() { Name = "C"},
            };

            // Query syntax
            var qresult = from p in products
                          join n in popularProductNames on p.Name equals n
                          select p;

            Console.WriteLine("Query syntax: {0}", string.Join(", ", qresult.Select(p => p.Name)));

            // Extension syntax
            var eresult = products.Join(popularProductNames, p => p.Name, pp => pp, (p,pp) => p);

            Console.WriteLine("Extension syntax: {0}", string.Join(", ", eresult.Select(p => p.Name)));

            Console.ReadLine();
        }
    }

    public class Product
    {
        public string Name { get; set; }
    }
}
