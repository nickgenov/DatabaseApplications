using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings
{
    class ListContinents
    {
        static void Main()
        {
            using (var context = new GeographyEntities())
            {
                var continents = context.Continents
                    .Select(c => c.ContinentName);

                foreach (var continent in continents)
                {
                    Console.WriteLine(continent);
                }
            }
        }
    }
}