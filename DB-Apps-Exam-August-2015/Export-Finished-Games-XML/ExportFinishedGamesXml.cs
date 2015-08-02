using System.Linq;
using EF_Mappings;
using System.Xml.Linq;
using System.Threading;

namespace Export_Finished_Games_XML
{

    class ExportFinishedGamesXml
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var context = new DiabloEntities();

            var gamesQuery = context.Games
                .Where(g => g.IsFinished == true)
                .Select(g => new
                {
                    GameName = g.Name,
                    GameDuration = g.Duration,
                    GameUsers = g.UsersGames
                        .Select(u => new
                        {
                            u.User.Username,
                            u.User.IpAddress
                        })
                })
                .OrderBy(g => g.GameName)
                .ThenBy(g => g.GameDuration)
                .ToList();

            XElement games = new XElement("games");

            foreach (var game in gamesQuery)
            {
                XElement xmlGame = new XElement("game",
                    new XAttribute("name", game.GameName));

                if (game.GameDuration != null)
                {
                    xmlGame.Add(new XAttribute("duration", game.GameDuration));
                }

                var xmlUsers = new XElement("users");

                foreach (var user in game.GameUsers)
                {
                    xmlUsers.Add(new XElement("user",
                        new XAttribute("username", user.Username),
                        new XAttribute("ip-address", user.IpAddress)));
                }

                xmlGame.Add(xmlUsers);
                games.Add(xmlGame);
            }

            games.Save("../../finished-games.xml");
        }
    }
}