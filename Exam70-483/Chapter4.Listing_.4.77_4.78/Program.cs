using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                Id = 2,
                Name = "John Doe"
            };

            using (Stream stream = new FileStream("data.xml", FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Person));
                ser.WriteObject(stream, p);
            }

            using (Stream stream = new FileStream("data.xml", FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Person));
                Person result = (Person)ser.ReadObject(stream);
                Console.WriteLine("{0} {1}", result.Id, result.Name);
            }

            Console.ReadLine();
        }
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        private bool isDirty = false;
    }
}
