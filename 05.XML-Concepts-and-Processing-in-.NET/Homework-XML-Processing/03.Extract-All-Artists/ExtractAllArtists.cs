using System;
using System.Collections.Generic;
using System.Xml;

namespace _03.Extract_All_Artists
{
    class ExtractAllArtists
    {
        static void Main()
        {
            var artists = new SortedSet<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlNode node in rootNode)
            {
                string artist = node["artist"].InnerText;
                artists.Add(artist);
            }

            foreach (var artist in artists)
            {
                Console.WriteLine(artist);
            }
        }
    }
}