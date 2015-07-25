using System;
using System.Xml;

namespace _06.Delete_Albums
{
    class DeleteAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            Console.WriteLine("Creating cheap-albums-catalog.xml...");

            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlNode node in rootNode)
            {
                double price = double.Parse(node["price"].InnerText);

                if (price > 20)
                {
                    node.RemoveAll();
                }
            }

            doc.Save("../../cheap-albums-catalog.xml");

            Console.WriteLine("XML created.");
        }
    }
}