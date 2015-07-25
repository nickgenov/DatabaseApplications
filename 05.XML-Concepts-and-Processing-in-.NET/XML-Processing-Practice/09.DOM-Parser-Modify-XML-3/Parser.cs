using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _09.DOM_Parser_Modify_XML_3
{
    class Parser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../library.xml");
            //double the prices of all books:

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string currentPrice = node["price"].InnerText;
                decimal newPrice = 2*decimal.Parse(currentPrice);
                node["price"].InnerText = newPrice.ToString();
            }

            Console.WriteLine("XML changed:");
            Console.WriteLine(doc.OuterXml);

            doc.Save("../../libraryNew.xml");
        }
    }
}