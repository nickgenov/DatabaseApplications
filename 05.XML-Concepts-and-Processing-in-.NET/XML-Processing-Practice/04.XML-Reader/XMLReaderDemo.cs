using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.XML_Reader
{
    class XMLReaderDemo
    {
        static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../library.xml"))
            {
                Console.WriteLine("Book titles in the library:");
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }

            using (XmlReader reader = XmlReader.Create("../../library.xml"))
            {
                Console.WriteLine("xml element names in the file:");
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        Console.WriteLine(reader.Name);
                    }
                }
            }
        }
    }
}