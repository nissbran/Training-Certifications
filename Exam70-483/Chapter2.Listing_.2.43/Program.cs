using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// You can also use generics when defining interfaces. 
    /// For example, if you are implementing the repository pattern 
    /// (a repository offers access to objects stored in a database or some other storage type),
    /// you can use a generic type parameter so you don’t have to 
    /// create different interfaces for each entity that you want to store
    /// </summary>
    public static class Program
    {
        static void Main(string[] args)
        {

        }
    }
    
    class Product {}

    class ProductRepository : IRepository<Product>
    {
        public Product FindById(int id)
        {
            return new Product();
        }

        public IEnumerable<Product> All()
        {
            return new List<Product>();
        }
    }

    interface IRepository<T>
    {
        T FindById(int id);
        IEnumerable<T> All();
    }
}
