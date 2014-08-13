using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// One thing to note is that an interface might define a property with 
    /// only a get accessor while the implementing type also has a set accessor
    /// </summary>
    public static class Program
    {
        static void Main(string[] args)
        {
            IReadOnlyInterface value = new ReadAndWriteImplementation();
            //value.Value = 2;

            ReadAndWriteImplementation value2 = new ReadAndWriteImplementation();
            value2.Value = 2;
        }
    }

    interface IReadOnlyInterface
    {
        int Value { get; }
    }

    struct ReadAndWriteImplementation : IReadOnlyInterface
    {
        public int Value { get; set; }

        // In this case, the implementing class adds an extra set accessor.
        // The advantage of using this pattern is that if a user accesses your class through its interface,
        // it will see only the get accessor. 
        // Direct users of the class will see both the get and the set accessor. 
    }

}
