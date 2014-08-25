using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            string xml;
            using (StringWriter sw = new StringWriter())
            {
                Person p = new Person()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 23,
                };
                serializer.Serialize(sw, p);
                xml = sw.ToString();
            }

            Console.WriteLine(xml);

            using (StringReader sr = new StringReader(xml))
            {
                Person p = (Person)serializer.Deserialize(sr);
                Console.WriteLine("{0} {1} is {2} years old", p.FirstName, p.LastName, p.Age);
            }

            Console.ReadLine();
        }
    }

    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
