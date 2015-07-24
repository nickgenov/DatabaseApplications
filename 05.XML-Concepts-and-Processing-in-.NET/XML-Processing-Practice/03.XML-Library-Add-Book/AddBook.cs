using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _03.XML_Library_Add_Book
{
    class AddBook
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../library.xml");

            //Console.WriteLine(doc.DocumentElement.InnerXml);
            //Console.WriteLine(doc.DocumentElement.OuterXml);

            var book = doc.CreateElement("book");

            AppendChild(doc, book, "title", "Заглавие");
            AppendChild(doc, book, "author", "Stamat Stamatov");
            AppendChild(doc, book, "isbn", "5456456564");

            doc.DocumentElement.AppendChild(book);

            doc.Save("../../library-new.xml");
        }

        private static void AppendChild(XmlDocument doc, XmlElement element, string tag, string tagContent)
        {
            var title = doc.CreateElement(tag);
            title.InnerText = tagContent;
            element.AppendChild(title);
        }
    }
}