using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
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
                Id = 3,
                Name = "John Doe JSON"
            };

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
                ser.WriteObject(stream, p);

                stream.Position = 0;
                
                StreamReader streamReader = new StreamReader(stream);
                Console.WriteLine(streamReader.ReadToEnd());

                stream.Position = 0;
                Person result = (Person)ser.ReadObject(stream);
                Console.WriteLine("Memory: {0} {1}", result.Id, result.Name);
            }

            using (Stream stream = new FileStream("data.json", FileMode.Create))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
                ser.WriteObject(stream, p);
            }

            using (Stream stream = new FileStream("data.json", FileMode.Open))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
                Person result = (Person)ser.ReadObject(stream);
                Console.WriteLine("File: {0} {1}", result.Id, result.Name);
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
