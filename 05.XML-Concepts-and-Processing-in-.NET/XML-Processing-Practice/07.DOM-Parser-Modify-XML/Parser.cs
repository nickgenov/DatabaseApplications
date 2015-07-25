using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _07.DOM_Parser_Modify_XML
{
    class Parser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../library.xml");

            XmlElement rootNode = doc.DocumentElement;
            rootNode.RemoveAll();

            XmlElement newElement = doc.CreateElement("book");
            doc.DocumentElement.AppendChild(newElement);

            doc.Save("../../library.xml");

            Console.WriteLine(doc.OuterXml);
        }
    }
}