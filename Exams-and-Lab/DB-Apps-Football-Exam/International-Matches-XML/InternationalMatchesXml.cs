using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using EF_Football_Mappings;

namespace International_Matches_XML
{
    class InternationalMatchesXml
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            using (var context = new FootballEntities())
            {
                var internationalMatches = context.InternationalMatches
                    .Select(im => new
                    {
                        HomeCountryName = im.CountryHome.CountryName,
                        AwayCountryName = im.CountryAway.CountryName,

                        HomeCode = im.HomeCountryCode,
                        AwayCode = im.AwayCountryCode,

                        HomeScore = im.HomeGoals,
                        AwayScore = im.AwayGoals,

                        MatchDate = im.MatchDate,

                        League = im.League.LeagueName
                    })
                    .OrderBy(im => im.MatchDate)
                    .ThenBy(im => im.HomeCountryName)
                    .ThenBy(im => im.AwayCountryName)
                    .ToList();

                XElement matches = new XElement("matches");

                foreach (var match in internationalMatches)
                {
                    XElement xmlMatch = new XElement("match", 
                        new XElement("home-country", 
                            new XAttribute("code", match.HomeCode),
                            match.HomeCountryName),
                        new XElement("away-country",
                            new XAttribute("code", match.AwayCode),
                            match.AwayCountryName)
                            );

                    if (match.League != null)
                    {
                        xmlMatch.Add(new XElement("league", match.League));
                    }
                    if (match.HomeScore != null && match.AwayScore != null)
                    {
                        xmlMatch.Add(new XElement("score", string.Format("{0}-{1}", match.HomeScore, match.AwayScore)));
                    }

                    if (match.MatchDate != null)
                    {
                        var dateHours = match.MatchDate.Value.Hour;
                        var dateMinutes = match.MatchDate.Value.Minute;
                        DateTime date = DateTime.Parse(match.MatchDate.ToString());

                        if (dateHours != 0 || dateMinutes != 0)
                        {
                            xmlMatch.Add(new XAttribute("date-time", date.ToString("dd-MMM-yyyy hh:mm")));
                        }
                        else
                        {
                            xmlMatch.Add(new XAttribute("date", date.ToString("dd-MMM-yyyy")));
                        }
                    }


                    matches.Add(xmlMatch);
                }

                //Console.WriteLine(matches);

                matches.Save("../../international-matches.xml");
            }
        }
    }
}