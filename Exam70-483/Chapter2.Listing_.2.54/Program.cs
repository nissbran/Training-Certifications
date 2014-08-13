using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// IComparable 
    /// This interface is used to sort elements.
    /// The CompareTo method returns an int value that shows how two elements are related. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order> {
                 new Order { Created = new DateTime(2012, 12, 1 )},     
                 new Order { Created = new DateTime(2012, 1, 6 )},    
                 new Order { Created = new DateTime(2012, 7, 8 )},    
                 new Order { Created = new DateTime(2012, 2, 20 )},
            };

            orders.Sort();

            // The call to orders.Sort() calls the CompareTo method to sort the items. 
            // After sorting, the list contains the ordered Orders. 
        }
    }

    // IComparable also has a generic version: IComparable<T>.
    // Especially when dealing with methods from the .NET Framework, 
    // it’s a good idea to implement both IComparable and IComparable<T>.
    // Of course, you can share some code between those two implementations.
    class Order : IComparable, IComparable<Order>
    {
        public DateTime Created { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Order o = obj as Order;

            if (o == null)
            {
                throw new ArgumentException("Object is not an Order");
            }

            return this.Created.CompareTo(o.Created);
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;

            return this.Created.CompareTo(other.Created);
        }
    }
}
