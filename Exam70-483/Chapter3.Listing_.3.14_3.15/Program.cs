using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Chapter3
{
    /// <summary>
    /// Validating XML
    /// 
    /// An XML file can be described by using an XML Schema Definition (XSD).
    /// This XSD can be used to validate an XML file. 
    /// </summary>
    class Program
    {
        private const string XmlString =
            "<?xml version=\"1.0\" encoding=\"utf-16\" ?>" +
            "<Person xmlns:xsi=\"http://www.w3.org/2001/XMLSchemainstance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                "<FirstName>John</FirstName>" +
                "<LastName>Doe</LastName>" +
                "<Age>42</Age>" +
            "</Person>";
        private const string XsdPath = "Person.xsd";
        private const string XmlPath = "Person.xml";

        // You can create an XSD file for this schema by using the XML Schema Definition Tool (Xsd.exe) that is a part of Visual Studio.
        // This tool can generate XML Schema files or C# classes. 

        static void Main(string[] args)
        {
            ValidateXML();
            ValidateXMLWithLinq();

            Console.ReadLine();
        }

        public static void ValidateXML()
        {
            XmlReader reader = XmlReader.Create(XmlPath);
            XmlDocument document = new XmlDocument();
            document.Schemas.Add("", XsdPath);
            document.Load(reader);

            var eventHandler = new ValidationEventHandler(ValidationEventHandler);
            document.Validate(eventHandler);

            // If there is something wrong with the XML file, such as a non-existing element,
            // the Valid tionEventHandler is called. 
            // Depending on the type of validation error, you can decide which action to take.
        }

        static void ValidationEventHandler(object sernder, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning: {0}", e.Message);
                    break;
            }

        }

        /// <summary>
        /// Another way to do it with XDocument
        /// </summary>
        public static void ValidateXMLWithLinq()
        {
            XmlReader reader = XmlReader.Create(XmlPath);
            var doc = XDocument.Load(reader, LoadOptions.None);

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XsdPath);

            doc.Validate(schemas, (o, e) =>
            {
                switch (e.Severity)
                {
                    case XmlSeverityType.Error:
                        Console.WriteLine("Error: {0}", e.Message);
                        break;
                    case XmlSeverityType.Warning:
                        Console.WriteLine("Warning: {0}", e.Message);
                        break;
                }
            });
        }


    }
}
