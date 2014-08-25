using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = File.OpenText("People.json"))
            {
                var text = stream.ReadToEnd();

                var data = JsonConvert.DeserializeObject<People>(text);
            
            }

        }
    }

    [DataContract]
    public class People
    {
        [DataMember(Name = "persons")]
        public List<Person> Persons { get; set; }
    }

    [DataContract]
    public class Person
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "contactDetails")]
        public ContactDetails Details { get; set; }
    }

    [DataContract]
    public class ContactDetails
    {
        [DataMember(Name = "emailAddress")]
        public string EmailAddress { get; set; }

        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
