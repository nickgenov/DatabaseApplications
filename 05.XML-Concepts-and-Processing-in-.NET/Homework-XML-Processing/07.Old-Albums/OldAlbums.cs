using System;
using System.Collections.Generic;
using System.Xml;

namespace _07.Old_Albums
{
    class OldAlbums
    {
        static void Main()
        {
            var oldAlbums = new Dictionary<string, decimal>();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            string xPathQuery = "/albums/album";
            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                int albumYear = int.Parse(album["year"].InnerText);
                int currentYear = DateTime.Now.Year;
                int albumAge = currentYear - albumYear;

                if (albumAge >= 5)
                {
                    string albumName = album["name"].InnerText;
                    decimal albumPrice = decimal.Parse(album["price"].InnerText);

                    oldAlbums[albumName] = albumPrice;
                }
            }

            foreach (var entry in oldAlbums)
            {
                Console.WriteLine("Album: {0}, price: {1}", entry.Key, entry.Value);
            }
        }
    }
}