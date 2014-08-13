using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //  Seeing whether an attribute is defined 
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
            {
                Console.WriteLine("Person is serializable");
            }

            // Getting a specific attribute instance 
            //ConditionalAttribute conditionalAttribute = (ConditionalAttribute)Attribute.GetCustomAttribute(
            //    typeof(ConditionalClass), 
            //    typeof(ConditionalAttribute));

        }
    }

    [Serializable]
    class Person
    {
        public string FirstName { get; set; }

        [Conditional("test")]
        public void TestMethod() { }
    }

    /// <summary>
    /// When creating your own custom attribute from scratch, 
    /// you also have to define the targets on which an attribute can be used.
    /// For example, you may want your attribute to be used only on methods and parameters
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MyMethodAndParameterAttribute : Attribute
    {

    }

    /// <summary>
    /// Defining the usage of an attribute is done by applying an attribute. 
    /// You can combine as many targets as you want.
    /// You can also use the AllowMultiple parameter to enable multiple instances of one attribute to a single type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class MyMultipleUsageAttribute : Attribute
    {

    }

    /// <summary>
    /// After having declared your custom attribute, you can add properties to it and a constructor to initialize your attribute. 
    /// Be aware, however, that attributes require all properties to be read-write.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)] 
    public class CompleteCustomerAttribute : Attribute
    {
        public string Description { get; set; }
        public CompleteCustomerAttribute(string description)
        {
            Description = description;
        }
    }
}
