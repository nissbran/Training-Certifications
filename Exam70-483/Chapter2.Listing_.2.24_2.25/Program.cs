using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// User-defined conversions 
    /// 
    /// When creating your own types, you can add support for both implicit and explicit conversions. 
    /// Suppose you are working on a Money class that encapsulates all kinds of rounding algorithms for working with different currencies. 
    /// 
    /// This example shows some of the implicit and explicit conversion you can add.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Now, when working with the Money class, you can use an implicit conversion
            // to decimal and an explicit conversion to int
            Money m = new Money(42.42M);
            decimal amount = m;
            int truncatedAmount = (int)m;

            // Adding these kinds of conversion can really improve the usability of your type.
            // As you can see, the implicit and explicit operator should be declared as a public static method on your class.
            // You need to specify the return type (the type you are casting to) 
            // and the type you are casting from (an instance of your class).
        }
    }

    class Money
    {
        public decimal Amount { get; set; }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        public static explicit operator int(Money money)
        {
            return (int)money.Amount;
        }
    }
}
