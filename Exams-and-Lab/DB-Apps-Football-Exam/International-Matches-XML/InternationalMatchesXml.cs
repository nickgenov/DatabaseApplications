using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Football_Mappings;

namespace International_Matches_XML
{
    class InternationalMatchesXml
    {
        static void Main()
        {
            using (var context = new FootballEntities())
            {
                var matches = context.InternationalMatches
                    .Select(im => new
                    {
                        homeCountry = im.CountryHome.CountryName,
                        homeCode = im.CountryHome.CountryCode,
                        awayCountry = im.CountryAway.CountryName,
                        awayCode = im.CountryAway.CountryCode,
                        homeGoals = im.HomeGoals,
                        awayGoals = im.AwayGoals,
                        matchDate = im.MatchDate
                    });



            }
        }
    }
}