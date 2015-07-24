using System;
using System.Linq;

namespace _03.DatabaseFirstGeorgraphy
{
    class Program
    {
        static void Main()
        {
            using (var context = new GeographyEntities())
            {
                var countries = context.Countries
                    .Where(c => c.Continent.ContinentName == "Europe")
                    .Select(c => new
                    {
                        Country = c.CountryName,
                        Capital = c.Capital,
                        Population = c.Population
                    })
                    .OrderBy(c => c.Country);

                foreach (var c in countries)
                {
                    Console.WriteLine("{0} - capital {1} - population - {2}", c.Country, c.Capital, c.Population);
                }

                context.Currencies.Add(new Currency
                {
                    CurrencyCode = "AAA",
                    Description = "BLAAAAA"
                });

                //context.SaveChanges();

                var country = context.Countries
                    .First(c => c.CountryName == "Bulgaria");

                country.CountryName = "Bulgaristan";
                //context.SaveChanges();

            }
        }
    }
}