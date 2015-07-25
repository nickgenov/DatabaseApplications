using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _14.LINQ_to_XML
{
    class LinqXMLSearch
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("../../books.xml");

            var books =
                from book in doc.Descendants("book")
                where book.Element("title").Value.Contains("4.0")
                select new
                {
                    Title = book.Element("title").Value,
                    Author = book.Element("author").Value
                };

            foreach (var book in books)
            {
                Console.WriteLine("{0} by {1}", book.Title, book.Author);
            }
        }
    }
}