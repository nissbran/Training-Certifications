using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using XmlReader to query
            using (StreamReader fs = File.OpenText("People.xml"))
            {
                string text = fs.ReadToEnd();

                using (StringReader stringReader = new StringReader(text))
                using (XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings() { IgnoreWhitespace = true }))
                {
                    xmlReader.MoveToContent();
                    xmlReader.ReadStartElement("people");

                    string firstName = xmlReader.GetAttribute("firstName");
                    string lastName = xmlReader.GetAttribute("lastName");

                    Console.WriteLine("Persion: {0} {1}", firstName, lastName);
                    xmlReader.ReadStartElement("person");

                    Console.WriteLine("ContactDetails");

                    xmlReader.ReadStartElement("contactdetails");
                    xmlReader.ReadStartElement("emailaddress");
                    string emailAddress = xmlReader.Value;

                    Console.WriteLine("Email address: {0}", emailAddress);
                }
            }

            Console.ReadLine();

            // Using XDocument to query
            XDocument xdoc = XDocument.Load("People.xml");
            var xemailAddress = xdoc.Element("people").Element("person").Element("contactdetails").Element("emailaddress").Value;
            Console.WriteLine("Email address: {0}", xemailAddress);

            // Using XmlWriter to create xml
            using (StringWriter stream = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("People");
                writer.WriteStartElement("Person");
                writer.WriteAttributeString("firstName", "John");
                writer.WriteAttributeString("lastName", "Doe");
                writer.WriteStartElement("ContactDetails");
                writer.WriteElementString("EmailAddress", "john@unknown.com");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();

                Console.WriteLine(stream.ToString());
            }

            Console.ReadLine();

            // Using XmlDocument to parse and add to xml
            XmlDocument doc = new XmlDocument();
            doc.Load("People.xml");

            XmlNodeList nodes = doc.GetElementsByTagName("person");

            // Output the names of the people in the document 
            foreach (XmlNode node in nodes)
            {
                string firstName = node.Attributes["firstname"].Value;
                string lastName = node.Attributes["lastname"].Value;
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }

            // Start creating a new node
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");

            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstname");
            firstNameAttribute.Value = "Foo";

            XmlAttribute lastNameAttribute = doc.CreateAttribute("lastname");
            lastNameAttribute.Value = "Bar";

            newNode.Attributes.Append(firstNameAttribute);
            newNode.Attributes.Append(lastNameAttribute);

            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine("Modified xml...");
            doc.Save(Console.Out);

            Console.ReadLine();

            // Using XDocument to parse and add to xml
            XDocument x2doc = XDocument.Load("People.xml");

            foreach (var person in x2doc.Descendants("person"))
            {
                string firstName = person.Attribute("firstname").Value;
                string lastName = person.Attribute("lastname").Value;
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }

            x2doc.Root.Add(new XElement("person",
                                new XAttribute("firstname", "Foo"),
                                new XAttribute("lastname", "Bar")));
            Console.WriteLine("Modified xml with XDocument...");
            x2doc.Save(Console.Out);

            Console.ReadLine();

            // Using XPath query
            XmlDocument xpathDoc = new XmlDocument();
            xpathDoc.Load("People.xml");

            XPathNavigator nav = xpathDoc.CreateNavigator();
            string query = "//people/person[@firstname='jane']";
            XPathNodeIterator iterator = nav.Select(query);

            Console.WriteLine(iterator.Count);

            while (iterator.MoveNext())
            {
                string firstName = iterator.Current.GetAttribute("firstname", "");
                string lastName = iterator.Current.GetAttribute("lastname", "");
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }

            Console.ReadLine();
        }
    }
}
