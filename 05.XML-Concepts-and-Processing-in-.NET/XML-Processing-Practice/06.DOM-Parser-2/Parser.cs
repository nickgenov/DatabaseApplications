using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _06.DOM_Parser_2
{
    class Parser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../library.xml");

            XmlElement rootNode = doc.DocumentElement;
            Console.WriteLine("Root node name: {0}", rootNode.Name);

            Console.WriteLine("Root node attributes:");
            foreach (XmlAttribute attribute in rootNode.Attributes)
            {
                Console.WriteLine("{0} = {1}", attribute.Name, attribute.Value);
            }
            Console.WriteLine();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.ChildNodes.Count != 0)
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        Console.WriteLine("Book {0} = {1}", childNode.Name, childNode.InnerText);
                    }
                    Console.WriteLine();
                }
            }

            //XmlAttributeCollection way use:

            XmlAttributeCollection attrCollection = doc.DocumentElement.Attributes;
            foreach (XmlAttribute attr in attrCollection)
            {
                Console.WriteLine("{0} = {1}", attr.Name, attr.Value);
            }
            Console.WriteLine();

            //XmlNodeList way of use:

            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode innerNode in node)
                {
                    Console.WriteLine("Book {0}: {1}", innerNode.Name, innerNode.InnerText);
                }
            }
            Console.WriteLine();

            //ParentNode:

            foreach (XmlNode node in nodeList)
            {
                Console.WriteLine("Parent node name: {0}", node.ParentNode.Name);
            }
            Console.WriteLine();

            //FirstChild, LastChild:

            Console.WriteLine(doc.DocumentElement.FirstChild.Name);
            Console.WriteLine(doc.DocumentElement.LastChild.Name);
            Console.WriteLine();

            //InnerXml, OuterXml

            Console.WriteLine("OuterXml:");
            Console.WriteLine(doc.DocumentElement.FirstChild.OuterXml);
            Console.WriteLine();
            Console.WriteLine("InnerXml:");
            Console.WriteLine(doc.DocumentElement.FirstChild.InnerXml);
            Console.WriteLine();

        }
    }
}