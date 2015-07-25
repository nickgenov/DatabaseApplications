using System;
using System.Xml;

namespace _02.Extract_Album_Names
{
    class ExtractAlbumNames
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode)
            {
                Console.WriteLine("Album: {0}", node["name"].InnerText);
            }
        }
    }
}