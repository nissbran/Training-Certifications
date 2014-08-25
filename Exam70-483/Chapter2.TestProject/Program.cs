using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.TestProject
{
    class Program
    {
        private static Person person = new Person();
        private static Customer cust = new Customer();

        static void Main(string[] args)
        {
            //cust = (Customer)person ;
            person = cust;
            person = cust as Person;
            person = (Person)cust;

            int i = 10;
            object iObject = i;
            iObject = 20;
        }

    }

    class Person : IEnumerable,IEnumerator
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public object Current
        {
            get { throw new NotImplementedException(); }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    class Customer : Person {
        
        public Customer() :
            this(2)
        {
            int ii = 33;
        }

        public Customer(int i)
        {
            int sss = i * 2;
        }

        public Customer(string test)
        {

        }
    }
}
