using System.Linq;
using System.Web.Script.Serialization;
using EF_Mappings;
using System.IO;


namespace Export_Rivers_JSON
{
    class ExportRiversJson
    {
        static void Main()
        {
            using (var context = new GeographyEntities())
            {
                var riverQuery = context.Rivers
                    .OrderByDescending(r => r.Length)
                    .Select(r => new
                    {
                        riverName = r.RiverName,
                        riverLength = r.Length,
                        countries = r.Countries
                            .OrderBy(c => c.CountryName)
                            .Select(c => c.CountryName)
                    });

                //Console.WriteLine(riverQuery);

                var jsonRivers = new JavaScriptSerializer().Serialize(riverQuery);

                System.IO.File.WriteAllText(@"../../rivers.json", jsonRivers);
            }
        }
    }
}