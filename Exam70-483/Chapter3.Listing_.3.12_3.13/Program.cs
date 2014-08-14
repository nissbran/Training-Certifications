using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Chapter3
{
    /// <summary>
    /// Validating JSON
    /// 
    /// JSON is a popular format that has its roots in the JavaScript world. 
    /// It’s a compact way to represent some data. XML has a stricter schema and is considered more verbose, but certainly has its uses.
    /// It’s important to make sure that this data is valid before you start using it.
    /// 
    /// 
    /// </summary>
    class Program
    {
        private const string JsonTest = "{ " +
            "\"FirstName\" : \"Nisse\"," +
            "\"LastName\" : \"Nissesson\"" +
            " }";

        static void Main(string[] args)
        {
            var result = IsJson(JsonTest);
            DeserializeJson(JsonTest);
        }

        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}") ||
                   input.StartsWith("[") && input.EndsWith("]");
        }

        /// <summary>
        ///  The .NET Framework offers the JavaScriptSerializer that you can use to deserialize a JSON string into an object.
        ///  You can find the JavaScriptSerializer in the System.Web.Extensions
        ///  dynamic-link library (DLL) in the System.Web.Script.Serialization namespace. 
        /// </summary>
        /// <param name="input"></param>
        public static void DeserializeJson(string input)
        {
            var serializer = new JavaScriptSerializer();
            var result = serializer.Deserialize<Dictionary<string, object>>(input);

            // In this case, you are deserializing the data to a Dictionary<string,object>. 
            // You can then loop through the dictionary to see the property names and their values.

            // Its also possible to match to an type
            var personResult = serializer.Deserialize<Person>(input);
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
