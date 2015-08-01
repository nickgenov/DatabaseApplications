using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using EF_Mappings;

namespace Export_Photographs_XML
{
    class ExportPhotographsXml
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            using (var context = new PhotographySystemEntities())
            {
                var photographsQuery = context.Photographs
                    .Select(p => new 
                    {
                        Title = p.Title,
                        Category = p.Category.Name,
                        Link = p.Link,
                        Camera = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Camera.Model,
                        CameraMegapixels = p.Equipment.Camera.Megapixels.Value,

                        Lens = p.Equipment.Lens.Manufacturer.Name + " " + p.Equipment.Lens.Model,
                        LensPrice = p.Equipment.Lens.Price
                    }).
                    OrderBy(p => p.Title)
                    .ToList();

                XElement photographs = new XElement("photographs");

                foreach (var p in photographsQuery)
                {
                    XElement xmlPhoto = null;

                    if (p.LensPrice != null)
                    {
                        xmlPhoto = new XElement("photograph",
                        new XAttribute("title", p.Title),
                        new XElement("category", p.Category),
                        new XElement("link", p.Link),
                        new XElement("equipment",
                            new XElement("camera",
                                new XAttribute("megapixels", p.CameraMegapixels),
                                p.Camera),
                        new XElement("lens", 
                            new XAttribute("price", string.Format("{0:F2}", p.LensPrice)),
                            p.Lens)
                        ));
                    }
                    else
                    {
                        xmlPhoto = new XElement("photograph",
                        new XAttribute("title", p.Title),
                        new XElement("category", p.Category),
                        new XElement("link", p.Link),
                        new XElement("equipment",
                            new XElement("camera",
                                new XAttribute("megapixels", p.CameraMegapixels),
                                p.Camera),
                        new XElement("lens", p.Lens)
                        ));
                    }
                    photographs.Add(xmlPhoto);
                }

                Console.WriteLine(photographs);

                photographs.Save("../../photographs.xml");
            }
        }
    }
}