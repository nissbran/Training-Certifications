using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// IEnumerable 
    /// 
    /// The IEnumerable and IEnumerator interface in .NET helps you to implement the iterator pattern,
    /// which enables you to access all elements in a collection without caring about how it’s exactly implemented. 
    /// You can find these interfaces in the System.Collection and System.Collections.Generic namespaces. 
    /// When using the iterator pattern, you can just as easily iterate over the elements in an array,
    /// a list, or a custom collection. It is heavily used in LINQ, which can access all kinds of collections
    /// in a generic way without actually caring about the type of collection.
    /// 
    /// The IEnumerable interface exposes a GetEnumerator method that returns an enumerator. 
    /// The enumerator has a MoveNext method that returns the next item in the collection. 
    ///
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Listing 2-55
            // The foreach statement in C# is some nice syntactic sugar that hides 
            // from you that you are using the GetEnumerator and MoveNext methods
            var numbers = new List<int> { 1, 2, 3, 4, 5, 7, 9 };
            using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }

            // The GetEnumerator function on an IEnumerable returns an IEnumerator. 
            // You can think of this in the way it’s used on a database: 
            //  IEnumerable<T> is your table and 
            //  IEnumerator is a cursor that keeps track of where you are in the table. 
            // It can only move to the next row. You can have multiple database cursors
            // around that all keep track of their own state.

            Console.ReadLine();
        }

        class Person
        {
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
        }

        /// <summary>
        ///  Implementing IEnumerable<T> on a custom type 
        ///  
        /// Before C# 2 implementing IEnumerable on your own types was quite a hassle. 
        /// You need to keep track of the current state and implement other functionality 
        /// such as checking whether the collection was modified while you were enumerating over it. 
        /// C# 2 made this a lot easier, as this class shows. 
        /// </summary>
        class People : IEnumerable<Person>
        {
            Person[] people;

            public People(Person[] people)
            {
                this.people = people;
            }

            public IEnumerator<Person> GetEnumerator()
            {
                for (int i = 0; i < people.Length; i++)
                {
                    yield return people[i];
                }
            }
            // Notice the yield return in the GetEnumerator function. 
            // Yield is a special keyword that can be used only in the context of iterators. 
            // It instructs the compiler to convert this regular code to a state machine.
            // The generated code keeps track of where you are in the collection and 
            // it implements methods such as MoveNext and Current. 

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
