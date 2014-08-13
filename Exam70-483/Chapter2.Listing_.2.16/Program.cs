using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Extension methods 
    /// 
    /// In .NET 4.0, a new capability was added called extension methods,
    /// which enable you to add new capabilities to an existing type. 
    /// You don’t need to make any modifications to the existing type; 
    /// just bring the extension method into scope and you can call it like a regular instance method. 
    /// Extension methods need to be declared in a nongeneric, non-nested, static class.
    /// 
    /// This example shows the creation of an extension method.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var calc = new Calculator();
            var product = new Product() { Price = 49 };

            Console.WriteLine(calc.CalculateDiscount(product));
            Console.ReadLine();
        }
    }

    public class Product
    {
        public decimal Price { get; set; }
    }

    public static class MyExtensions
    {
        /// <summary>
        /// Notice that the Discount method has this Product as its first argument. 
        /// The special this keyword makes this method an extension method. 
        /// </summary>
        public static decimal Discount(this Product product)
        {
            return product.Price * .9m;
        }
    }

    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {
            return p.Discount();
        }
    }
}
