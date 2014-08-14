using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// Using hashing
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // -- Listing 3-23
            // The .NET Framework offers a couple of classes to generate hash values. 
            // The algorithms that the .NET Framework offers are optimized hashing algorithms
            // that output a significantly different hash code for a small change in the data.

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();

            string data = "A paragraph of text";
            byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of changed text"; 
            byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data)); 

            data = "A paragraph of text";
            byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));

            Console.WriteLine(hashA.SequenceEqual(hashB));
            Console.WriteLine(hashA.SequenceEqual(hashC));

            Console.ReadLine();
        }
    }

    /// <summary>
    /// To understand what hashing is and see some of the ideas behind a hash code, take a look at the Set class. 
    /// A set stores only unique items, so it sees whether an item already exists before adding it.
    /// 
    /// For each item that you add, you have to loop through all existing items.
    /// This doesn’t scale well and leads to performance problems when you have a large amount of items. 
    /// It would be nice if you somehow needed to check only a small subgroup instead of all the items.
    /// </summary>
    class Set<T>
    {
        private List<T> list = new List<T>();

        public void Insert(T item)
        {
            if (!Contains(item))
                list.Add(item);
        }

        public bool Contains(T item)
        {
            foreach (T member in list)
            {
                if (member.Equals(item))
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    /// This is where a hash code can be used.
    /// Hashing is the process of taking a large set of data and mapping it to a smaller data set of fixed length. 
    /// For example, mapping all names to a specific integer. 
    /// Instead of checking the complete name, you would have to use only an integer value. 
    /// 
    /// By using hashing, you can improve the design of the set class. 
    /// You split the data in a set of buckets. 
    /// Each bucket contains a subgroup of all the items in the set. 
    /// </summary>
    class HashSet<T>
    {
        private List<T>[] buckets = new List<T>[100];

        public void Insert(T item)
        {
            int bucket = GetBucket(item.GetHashCode());
            if (Contains(item, bucket)) 
                return;
            if (buckets[bucket] == null)
                buckets[bucket] = new List<T>();
            buckets[bucket].Add(item);
        }

        public bool Contains(T item)
        {
            return Contains(item, GetBucket(item.GetHashCode()));
        }

        private int GetBucket(int hashcode)
        {
            // A Hash code can be negative. To make sure that you end up with a positive           
            // value cast the value to an unsigned int. The unchecked block makes sure that           
            // you can cast a value larger then int to an int safely.  
            unchecked
            {
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }

        private bool Contains(T item, int bucket)
        {
            if (buckets[bucket] != null)
                foreach (T member in buckets[bucket])
                    if (member.Equals(item))
                        return true;
            return false;

            // If you look at the Contains method, you can see that it uses the GetHashCode method of each item.
            // This method is defined on the base class Object. 
            // In each type, you can override this method and provide a specific implementation for your type.
            // This method should output an integer code that describes your particular object.
            // As a general guideline, the distribution of hash codes must be as random as possible.
            // This is why the set implementation uses the GetHashCode method on each object to calculate in which bucket it should go. 
        }
    }
}
