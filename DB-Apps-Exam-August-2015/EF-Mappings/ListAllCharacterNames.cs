using System;
using System.Linq;

namespace EF_Mappings
{
    class ListAllCharacterNames
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var characterNames = context.Characters
                .Select(c => c.Name)
                .ToList();

            foreach (var name in characterNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}