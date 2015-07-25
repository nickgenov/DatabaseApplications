using System;
using System.Collections.Generic;
using System.Xml;

namespace _04.Extract_Number_of_Albums
{
    class ExtractNumberOfAlbums
    {
        static void Main()
        {
            var artistAlbumCount = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode)
            {
                string artist = node["artist"].InnerText;

                if (artistAlbumCount.ContainsKey(artist))
                {
                    artistAlbumCount[artist]++;
                }
                else
                {
                    artistAlbumCount[artist] = 1;
                }
            }

            foreach (KeyValuePair<string, int> keyValuePair in artistAlbumCount)
            {
                Console.WriteLine("{0} --- {1} albums", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}