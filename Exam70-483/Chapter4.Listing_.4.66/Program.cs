using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("People.xml");
            var personNames = from p in doc.Descendants("person")
                              where p.Descendants("phonenumber").Any()
                              let name = (string)p.Attribute("firstname") + " " + (string)p.Attribute("lastname")
                              orderby name
                              select name;
            
            Console.WriteLine(personNames.FirstOrDefault());
            Console.ReadLine();
                
        }
    }
}
