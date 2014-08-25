using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{

    /// <summary>
    /// Other useful LINQ operations are projection and grouping.
    /// When using projection, you select another type or an anonymous type as the result of your query.
    /// You project your results into it to focus only on the properties you really need.
    /// When using grouping, you group your data by a certain property and then work with that result.
    /// An example where this is useful is when you want to know how many items of each product you have sold.
    /// You can use the query from this example to calculate this.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product
            {
                Description = "Test"
            };

            var orders = new List<Order>()
                {
                    new Order {
                         OrderLines = new List<OrderLine>()
                         {
                            new OrderLine() { Amount = 22, Product = product1 },
                            new OrderLine() { Amount = 11, Product = new Product { Description = "Test" }},
                         }
                    },
                    new Order() { OrderLines = new List<OrderLine>() },
                    new Order {
                         OrderLines = new List<OrderLine>()
                         {
                            new OrderLine() { Amount = 22, Product = product1 },
                            new OrderLine() { Amount = 33, Product = new Product { Description = "Test" }},
                         }
                    },
                };

            // Grouping and projection to anonymous type
            var result = from o in orders
                         from l in o.OrderLines
                         group l by l.Product into p
                         select new
                         {
                             Product = p.Key,
                             Amount = p.Sum(x => x.Amount)
                         };

            Console.WriteLine("Group and projection: {0}", string.Join(", ",result.Select(x => x.Amount)));

            // Projection to existing type
            var result2 = from o in orders
                          from l in o.OrderLines
                          select new ProductAmount
                          {
                              Amount = l.Amount,
                              Description = l.Product.Description
                          };
            
            Console.WriteLine("Projection: {0}", string.Join(", ", result2.Select(x => x.Amount)));

            Console.ReadLine();

        }
    }

    public class ProductAmount
    {
        public string Description { get; set; }
        public int Amount { get; set; }
    }

    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderLine
    {
        public int Amount { get; set; }
        public Product Product { get; set; }
    }
    public class Order
    {
        public List<OrderLine> OrderLines { get; set; }
    }
}
