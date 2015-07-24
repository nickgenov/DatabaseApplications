using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _01.XML_Library_Reader
{
    class Reader
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"..\..\library.xml");

            var bookNodes = doc.DocumentElement.ChildNodes;
            foreach (XmlElement bookNode in bookNodes)
            {
                Console.WriteLine(bookNode.FirstChild.InnerText);
            }

            foreach (XmlElement bookNode in bookNodes)
            {
                Console.WriteLine(bookNode["title"].InnerText);
            }

            foreach (XmlElement bookNode in bookNodes)
            {
                Console.WriteLine(bookNode["title"].FirstChild.InnerText);
            }

            //XPath way to write the same thing:
            var titleNodes = doc.SelectNodes("/library/book/title");

            foreach (XmlElement titleNode in titleNodes)
            {
                Console.WriteLine(titleNode.InnerText);
            }

            Console.WriteLine();

            foreach (XmlElement bookNode in bookNodes)
            {
                Console.WriteLine("Title: {0}", GetInnerValue(bookNode, "title"));
                Console.WriteLine("Author: {0}", GetInnerValue(bookNode, "author"));
                Console.WriteLine("ISBN: {0}", GetInnerValue(bookNode, "isbn"));
                Console.WriteLine();
            }
            //Console.WriteLine(doc.OuterXml);
        }
        public static string GetInnerValue(XmlElement element, string tagName)
        {
            if (element[tagName] != null)
            {
                return element[tagName].InnerText;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}