using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductsShop.Data;

namespace ProductsShop.ConsoleClient
{
    class Client
    {
        static void Main()
        {
            using (var context = new ShopContext())
            {
                JObject products = JObject.Parse(File.ReadAllText("../../products.json"));

                JObject o1 = JObject.Parse(File.ReadAllText(@"c:\videogames.json"));

                // read JSON directly from a file
                using (StreamReader file = File.OpenText(@"c:\videogames.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o2 = (JObject)JToken.ReadFrom(reader);
                }
            }
        }
    }
}