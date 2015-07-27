using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EF_Mappings;

namespace Export_Monasteries_XML
{
    class ExportMonasteriesXml
    {
        static void Main()
        {
            using (var context = new GeographyEntities())
            {
                var countriesQuery = 
                    context.Countries
                    .Where(c => c.Monasteries.Count > 0)
                    .OrderBy(c => c.CountryName)
                    .Select(c => new
                    {
                        CountryName = c.CountryName,
                        Monasteries = c.Monasteries
                            .OrderBy(m => m.Name)
                            .Select(m => m.Name)
                    });

                //Console.WriteLine(monasteriesQuery);
            
                var xmlDoc = new XDocument();
                var xmlRoot = new XElement("monasteries");

                xmlDoc.Add(xmlRoot);

                foreach (var country in countriesQuery)
                {
                    var countryXml = new XElement("country", new XAttribute("name", country.CountryName));
                    xmlRoot.Add(countryXml);

                    foreach (var monastery in country.Monasteries)
                    {
                        var monasteryXml = new XElement("monastery", monastery);
                        countryXml.Add(monasteryXml);
                    }
                }

                //Console.WriteLine(xmlDoc);
                xmlDoc.Save("../../monasteries.xml");
            }
        }
    }
}