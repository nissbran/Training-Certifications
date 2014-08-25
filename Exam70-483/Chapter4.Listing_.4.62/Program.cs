using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    /// When you are working with a large data set, you probably want to implement paging. 
    /// When using paging, you don’t show all data at once to the user.
    /// Instead, you load it one page at a time. When data comes from an external resource such as a database,
    /// this can yield a significant performance gain. To implement paging, you can use the Skip and Take operators. 
    /// There is no query syntax for them, so you need to use the methods as you can see in this example.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var products = Enumerable.Repeat(new Product(), 40);

            var pagedProducts = products.Skip(10).Take(10);
        }
    }

    public class Product
    {
        public string Name { get; set; }
    }
}
