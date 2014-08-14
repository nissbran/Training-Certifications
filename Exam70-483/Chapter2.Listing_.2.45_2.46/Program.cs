using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// An interface defines only the public signature of a type. 
    /// Deriving from an interface doesn’t inherit any implementation code. 
    /// The derived type is completely free in how to implement the interface.
    /// When you do want to inherit implementation code, you can inherit from another class
    /// </summary>
    public static class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface IEntity
    {
        int Id { get; }
    }

    class Repository<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);
        }
    }

    class Order: IEntity
    {
        public int Id { get; set; }
    }

    class OrderRepository : Repository<Order>
    {
        public OrderRepository(IEnumerable<Order> orders) : base(orders)
        { }

        public IEnumerable<Order> FilterOrderOnAmount(decimal amount)
        {
            return new List<Order>();
        }
    }
}
