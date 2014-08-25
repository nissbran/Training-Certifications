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
            var orders = new List<Order>()
                {
                    new Order {
                         OrderLines = new List<OrderLine>()
                         {
                            new OrderLine(),
                            new OrderLine(),
                         }
                    },
                    new Order() { OrderLines = new List<OrderLine>() },
                    new Order {
                         OrderLines = new List<OrderLine>()
                         {
                            new OrderLine(),
                            new OrderLine(),
                         }
                    },
                };

            var averageNumberOfOrderLines = orders.Average(o => o.OrderLines.Count);

            Console.WriteLine(averageNumberOfOrderLines);
            Console.ReadLine();
        }
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
