using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _08.DOM_Parser_Modify_XML_2
{
    class Parser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../items.xml");

            string culture = doc.DocumentElement.Attributes["culture"].Value;
            CultureInfo numberFormat = new CultureInfo(culture);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Attributes["type"].Value == "beer")
                {
                    string currentPriceStr = node["price"].InnerText;
                    decimal currentPrice = decimal.Parse(currentPriceStr, numberFormat);
                    decimal newPrice = currentPrice/2;

                    node["price"].InnerText = newPrice.ToString(numberFormat);
                }
            }

            Console.WriteLine("Modified XML document:");
            Console.WriteLine(doc.OuterXml);

            doc.Save("../../itemsNew.xml");
        }
    }
}
