using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _15.LINQ_Create_XML_XElement
{
    class XElementCreateXml
    {
        static void Main()
        {
            var booksXml = new XElement("books",
                new XElement("book",
                    new XElement("author", "James Clavell"),
                    new XElement("title", "Shogun")
                    ),
                new XElement("book",
                    new XElement("title", "Tai Pan"),
                    new XElement("author", "James Clavell"),
                    new XAttribute("classics", "adventure novels")
                    ),
                new XElement("book",
                    new XElement("title", "Martin Eden"),
                    new XElement("author", "Jack London")
                    )
                );

            Console.WriteLine(booksXml);

            booksXml.Save("../../books.xml");
        }
    }
}
