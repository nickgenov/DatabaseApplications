using System;
using System.Collections.Generic;
using System.Xml;

namespace _10.StAX_XMLReader
{
    class ReaderExample
    {
        static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../students.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                    {
                        Console.WriteLine("Student name: {0}", reader.ReadElementString());
                    }
                }
            }
            Console.WriteLine();

            using (XmlReader reader = XmlReader.Create("../../library.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        Console.WriteLine("Book title: {0}", reader.ReadElementString());
                    }
                }
            }
            Console.WriteLine();

            using (XmlReader reader = XmlReader.Create("../../library.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "author")
                    {
                        Console.WriteLine("Book author: {0}", reader.ReadElementString());
                    }
                }
            }

            Console.WriteLine("\nElements in students.xml:\n");
            var elements = new HashSet<string>();

            using (XmlReader reader = XmlReader.Create("../../students.xml"))
            {
                
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && elements.Contains(reader.Name) == false)
                    {
                        Console.WriteLine(reader.Name);
                        elements.Add(reader.Name);
                    }
                }
            }
        }
    }
}