using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Football_Mappings
{
    class ListTeamNames
    {
        static void Main()
        {
            using (var context = new FootballEntities())
            {
                var teamNames = context.Teams
                    .Select(t => t.TeamName);

                foreach (var teamName in teamNames)
                {
                    Console.WriteLine(teamName);
                }
            }
        }
    }
}