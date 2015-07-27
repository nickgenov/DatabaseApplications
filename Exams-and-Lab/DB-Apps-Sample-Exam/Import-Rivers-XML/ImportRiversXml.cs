﻿using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using EF_Mappings;

namespace Import_Rivers_XML
{
    class ImportRiversXml
    {
        static void Main()
        {
            using (var context = new GeographyEntities())
            {
                var xmlDoc = XDocument.Load("../../rivers.xml");

                //Console.WriteLine(xmlDoc);

                var riverElements = xmlDoc.Root.Elements();
                foreach (var riverElement in riverElements)
                {
                    var riverEntity = new River();

                    riverEntity.RiverName = riverElement.Element("name").Value;
                    riverEntity.Length = int.Parse(riverElement.Element("length").Value);
                    riverEntity.Outflow = riverElement.Element("outflow").Value;

                    if (riverElement.Element("drainage-area") != null)
                    {
                        riverEntity.DrainageArea = int.Parse(riverElement.Element("drainage-area").Value);
                    }
                    if (riverElement.Element("average-discharge") != null)
                    {
                        riverEntity.AverageDischarge = int.Parse(riverElement.Element("average-discharge").Value);
                    }

                    ParseAndAddCountriesToRiver(riverElement, context, riverEntity);

                    context.Rivers.Add(riverEntity);
                }

                context.SaveChanges();
            }
        }

        private static void ParseAndAddCountriesToRiver(XElement riverElement, GeographyEntities context, River riverEntity)
        {
            var countryElements = riverElement.XPathSelectElements("countries/country");

            foreach (var countryElement in countryElements)
            {
                var countryName = countryElement.Value;
                var countryEntity = context.Countries
                    .Where(c => c.CountryName == countryName)
                    .FirstOrDefault();

                if (countryEntity != null)
                {
                    riverEntity.Countries.Add(countryEntity);
                }
                else
                {
                    throw new Exception(string.Format("Cannot find country {0} in the database", countryName));
                }
            }
        }
    }
}