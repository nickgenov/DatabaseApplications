using System.Linq;
using System.Web.Script.Serialization;
using System.IO;

namespace Export_Characters_And_Players_JSON
{
    using EF_Mappings;

    class ExportCharactersAndPlayersJson
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var characters = context.Characters
                .Select(c => new
                {
                    CharacterName = c.Name,
                    PlayedBy = 
                        c.UsersGames.
                        Select(u => new
                        {
                            u.User.Username
                        })
                })
                .OrderBy(c => c.CharacterName)
                .ToList();

            var json = new JavaScriptSerializer().Serialize(characters);
            File.WriteAllText("../../characters.json", json);
        }
    }
}