using System.Linq;
using EF_Mappings;
using System.Web.Script.Serialization;
using System.IO;

namespace Export_Manufacturers_Cameras_JSON
{
    class ExportManufacturersCamerasJson
    {
        static void Main()
        {

            using (var context = new PhotographySystemEntities())
            {
                var manufacturerCameras = context.Manufacturers
                    .Select(m => new
                    {
                        manufacturer = m.Name,
                        cameras = m.Cameras.Select(c => new
                        {
                            model = c.Model,
                            price = c.Price
                        })
                        .OrderBy(c => c.model)
                    })
                    .OrderBy(m => m.manufacturer)
                    .ToList();

                var json = new JavaScriptSerializer().Serialize(manufacturerCameras);

                File.WriteAllText("../../manufacturers-and-cameras.json", json);
            }
        }
    }
}