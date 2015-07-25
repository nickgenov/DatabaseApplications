using System;
using System.Collections.Generic;
using System.Xml;

namespace _05.XPath_Number_of_Albums
{
    class XPathNumberOfAlbums
    {
        static void Main()
        {
            var artistAlbumCount = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            string XPathArtist = "/albums/album/artist";

            XmlNodeList artistList = doc.SelectNodes(XPathArtist);

            foreach (XmlNode node in artistList)
            {
                string artist = node.InnerText;

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
