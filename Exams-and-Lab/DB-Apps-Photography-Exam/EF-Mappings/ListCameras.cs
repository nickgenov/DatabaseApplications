using System;
using System.Linq;

namespace EF_Mappings
{
    class ListCameras
    {
        static void Main()
        {
            using (var context = new PhotographySystemEntities())
            {
                var cameras = context.Cameras
                    .Select(c => new
                    {
                       CameraInfo = c.Manufacturer.Name + " " + c.Model
                    })
                    .OrderBy(c => c.CameraInfo)
                    .ToList();

                foreach (var camera in cameras)
                {
                    Console.WriteLine(camera.CameraInfo);
                }
            }
        }
    }
}