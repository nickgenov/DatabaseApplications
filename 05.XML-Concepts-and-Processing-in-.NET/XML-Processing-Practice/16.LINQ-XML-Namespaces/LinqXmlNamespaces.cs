using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _16.LINQ_XML_Namespaces
{
    class LinqXmlNamespaces
    {
        static void Main(string[] args)
        {
            XNamespace ns = "http://linqinaction.net";
            XNamespace anotherNs = "http://www.w3c.org/xml";

            var books = new XElement(XName.Get("books", "http://bookstore.org"));

            var bookFirst = new XElement(ns + "book",
                new XElement(ns + "title", "LINQ in Action"),
                new XElement(ns + "author", "Manning"),
                new XElement(ns + "author", "Steve Eichert"),
                new XElement(ns + "author", "Jim Wooley"),
                new XElement(anotherNs + "publisher", "Manning")
            );

            var bookSecond = new XElement(ns + "book",
                new XElement(ns + "title", "XML for Dummies"),
                new XElement(ns + "author", "Manning"),
                new XElement(ns + "author", "Steve Eichert"),
                new XElement(ns + "author", "Jim Wooley"),
                new XElement(anotherNs + "publisher", "Manning")
                );

            books.Add(bookFirst);
            books.Add(bookSecond);

            Console.WriteLine(books);

            books.Save("../../books.xml");
        }
    }
}
