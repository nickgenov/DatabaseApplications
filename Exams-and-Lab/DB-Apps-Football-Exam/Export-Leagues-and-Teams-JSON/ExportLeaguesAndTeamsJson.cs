using System;
using System.Linq;
using System.Web.Script.Serialization;
using EF_Football_Mappings;
using System.IO;

namespace Export_Leagues_and_Teams_JSON
{
    class ExportLeaguesAndTeamsJson
    {
        static void Main()
        {
            using (var context = new FootballEntities())
            {
                var leagues = context.Leagues
                    .Select(l => new
                    {
                        leagueName = l.LeagueName,
                        teams = l.Teams
                            .Select(t => t.TeamName)
                            .OrderBy(t => t)
                    })
                    .OrderBy(l => l.leagueName)
                    .ToList();

                //foreach (var league in leagues)
                //{
                //    Console.WriteLine("---------{0}", league.leagueName);

                //    foreach (var team in league.teams)
                //    {
                //        Console.WriteLine(team.TeamName);
                //    }
                //}

                var json = new JavaScriptSerializer().Serialize(leagues);
                File.WriteAllText("../../leagues-and-teams.json", json);
            }
        }
    }
}