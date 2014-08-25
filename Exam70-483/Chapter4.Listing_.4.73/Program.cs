using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    /// <summary>
    /// Binary serialization creates a compact stream of bytes. 
    /// One thing that’s different compared with XML serialization is that private fields are serialized by default.
    /// Another thing is that during deserialization, no constructors are executed. 
    /// You have to take this into account when working with binary serialization. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                Id = 1,
                Name = "John Doe",
            };

            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }

            using (Stream stream = new FileStream("data.bin", FileMode.Open))
            {
                Person dp = (Person)formatter.Deserialize(stream);

                Console.WriteLine("{0} {1}", dp.Id, dp.Name);
            }

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Just as with the XmlSerializer, you can prevent fields from being serialized.
    /// You do this by using the [NonSerialized] attribute. 
    /// Suppose that you don’t want to serialize the IsDirty field from the Person class. 
    /// </summary>
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NonSerialized]
        private bool isDirty = false;

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Console.WriteLine("OnSerializing.");
        }
        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Console.WriteLine("OnSerialized.");
        }
        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Console.WriteLine("OnDeserializing.");
        }
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Console.WriteLine("OnSerialized.");
        }
    }


    /// <summary>
    /// As you can see, implementing ISerializable consists of two important parts.
    /// The first is the GetObjectData method. This method is called when your object is serialized. 
    /// It should add the values that you want to serialize as key/value pairs to the SerializationInfo object that’s passed to the method. 
    /// One thing that’s important is that you should mark this method with a SecurityPermission attribute
    /// (you can find this attribute in the System.Security.Permissions namespace)
    /// so that it is allowed to execute serialization and deserialization code. 
    /// </summary>
    [Serializable]
    public class PersonComplex : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private bool isDirty = false;

        public PersonComplex() { }

        /// <summary>
        /// The other important step is adding a special protected constructor that takes a SerializationInfo and StreamingContext.
        /// This constructor is called during deserialization, and you use it to retrieve the values and initialize your object. 
        /// As you can see, you are free in choosing the names for the values that you add to the SerializationInfo. 
        /// </summary>
        protected PersonComplex(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetInt32("Value1");
            Name = info.GetString("Value2");
            isDirty = info.GetBoolean("Value3");
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value1", Id);
            info.AddValue("Value2", Name);
            info.AddValue("Value3", isDirty);
        }
    }

}
