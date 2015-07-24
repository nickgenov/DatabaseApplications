using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _01.XML_Library_XDocument
{
    class XDocumentExample
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("../../library.xml");

            var books =
                from b in doc.Descendants("book")
                select new
                {
                    Title = b.Descendants("title").FirstOrDefault() != null ? b.Descendants("title").FirstOrDefault().Value : ""
                };

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}