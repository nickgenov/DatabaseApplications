using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace _04.LINQ_to_JSON
{
    class LinqToJson
    {
        static void Main(string[] args)
        {
            var json = @"
            {
              name: 'Sofia',
              places: [{
               'name': 'Pri Ivan',
               'categories': [
                 {
                   'id': 1,
                   'name': 'food'
                 },
                 {
                   'id': 2,
                   'name': 'drinks'
                 }
               ],
               'location': {
                 'latitude': 42.69751,
                 'longitude': 23.32415
               }
             },{
               'name': 'Golyamata Parjola',
               'categories': [
                 {
                   'id': 1,
                   'name': 'food'
                 },
                 {
                   'id': 3,
                   'name': 'big meat'
                 }
               ],
               'location': {
                 'latitude': 43.69751,
                 'longitude': 23.32415
               }
             },{
               'name': 'Dalbokoto dano',
               'categories': [
                 {
                   'id': 4,
                   'name': 'beer'
                 },
                 {
                   'id': 2,
                   'name': 'drinks'
                 }
               ],
               'location': {
                 'latitude': 42.1,
                 'longitude': 23.2
               }
             }]
            }";

            var jsonObj = JObject.Parse(json);

            Console.WriteLine("Places in {0}", jsonObj["name"]);

            var index = 1;

            var jsonLinq = jsonObj["places"]
                .Select(pl =>
                    string.Format("{0}) {1} ({2})", index++, pl["name"],
                        string.Join(", ", pl["categories"].Select(cat => cat["name"]))));

            Console.WriteLine(jsonLinq);
        }
    }
}
