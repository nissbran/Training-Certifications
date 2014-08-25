using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4.Listing_._4._53
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new
            {
                FirstName = "John",
                LastName = "Doe"
            };

            Console.WriteLine(person.GetType().Name);
            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);
            Console.ReadLine();
        }
    }
}
