using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _13.XPath_Searching
{
    class XPathExample
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../items.xml");

            string xPathQuery = "/items/item[@type='beer']";

            XmlNodeList beerList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in beerList)
            {
                Console.WriteLine("{0}: {1}", node["name"].InnerText, node["price"].InnerText);
            }
        }
    }
}