using System;
using System.Xml;

namespace _05.DOM_Parser
{
    class Parser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            //doc.PreserveWhitespace = true;
            doc.Load("../../students.xml");

            Console.WriteLine("Loadex XML Document:");
            Console.WriteLine(doc.OuterXml);
            Console.WriteLine();

            XmlNode rootNode = doc.DocumentElement;
            Console.WriteLine("Root node: {0}", rootNode.Name);

            //USE XmlAttribute, not VAR!!!
            foreach (XmlAttribute attribute in rootNode.Attributes)
            {
                Console.WriteLine("Attribute: {0} = {1}", attribute.Name, attribute.Value);
            }
            Console.WriteLine();

            //USE XmlNode, not VAR!!!
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                Console.WriteLine("Student name: {0}", node["name"].InnerText);
                Console.WriteLine("Student gender: {0}", node["gender"].InnerText);
                Console.WriteLine("Student birth date: {0}", node["birth-date"].InnerText);
                Console.WriteLine("Student phone number: {0}", node["phone-number"].InnerText);
                Console.WriteLine("Student email: {0}", node["email"].InnerText);
                Console.WriteLine("Student university: {0}", node["university"].InnerText);
                Console.WriteLine("Student specialty: {0}", node["specialty"].InnerText);
            }
            Console.WriteLine();


            XmlNode rootNode2 = doc.DocumentElement;

            foreach (XmlAttribute attribute in rootNode2.Attributes)
            {
                Console.WriteLine("{0} = {1}", attribute.Name, attribute.Value);
            }
            Console.WriteLine();

            foreach (XmlNode node in rootNode2.ChildNodes)
            {
                Console.WriteLine("Student name: {0}", node["name"].InnerText);
            }
        }
    }
}