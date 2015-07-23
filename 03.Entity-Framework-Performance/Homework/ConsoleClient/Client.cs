using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Client
    {
        static void Main()
        {
            using (var context = new AdsEntities())
            {
                //Problem 1. Show Data from Related Tables

                //Using Entity Framework write a SQL query to select all ads from the database and later print their title, status, category, town and user. Do not use Include(…) for the relationships of the Ads. Check how many SQL commands are executed with the SQL ExpressProfiler (or a similar tool).

                var adsSelected = context.Ads
                    .Select(a => new
                    {
                        a.Title,
                        a.AdStatus.Status,
                        Category = a.Category.Name,
                        Town = a.Town.Name,
                        User = a.AspNetUser.Name
                    });

                //One SQL command is sent:
                foreach (var ad in adsSelected)
                {
                    Console.WriteLine("Title: {0}, status: {1}, category: {2}, town: {3}, user: {4}", ad.Title, ad.Status, ad.Category, ad.Town, ad.User);
                }

                var ads = context.Ads;

                //Many SQL commands are sent:
                foreach (var ad in ads)
                {
                    Console.WriteLine("Title: {0}, status: {1}, category: {2}, town: {3}, user: {4}",
                        ad.Title,
                        ad.AdStatus.Status,
                        (ad.CategoryId != null) ? ad.Category.Name : "no data",
                        (ad.TownId != null) ? ad.Town.Name : "no data",
                        ad.AspNetUser.Name);
                }

                //Add Include(…) to select statuses, categories, towns and users along with all ads. Compare the number of executed SQL statements and the performance before and after adding Include(…).

                foreach (var ad in context.Ads
                    .Include(a => a.AdStatus)
                    .Include(a => a.Category)
                    .Include(a => a.Town)
                    .Include(a => a.AspNetUser))
                {
                    Console.WriteLine("Title: {0}, status: {1}, category: {2}, town: {3}, user: {4}",
                        ad.Title,
                        ad.AdStatus.Status,
                        (ad.CategoryId != null) ? ad.Category.Name : "no data",
                        (ad.TownId != null) ? ad.Town.Name : "no data",
                        ad.AspNetUser.Name);
                }
            }
/*
+--------------------------+---------------+-----------------+
|                          | No Include(…) | With Include(…) |
+--------------------------+---------------+-----------------+
| Number of SQL statements | 30+           |               1 |
+--------------------------+---------------+-----------------+
*/

            using (var context = new AdsEntities())
            {
                //Problem 2. Play with ToList()

                //Using Entity Framework select all ads from the database, then invoke ToList(), then filter the ads whose status is Published; then select the ad title, category and town, then invoke ToList() again and finally order the ads by publish date. 

                //initialize the DB connection in order to measure more accurately
                var adsCount = context.Ads.Count();
                Console.WriteLine(adsCount);

                var timer = new Stopwatch();

                timer.Start();
                IncorrectToListUse(context);
                Console.WriteLine("Incorrect use of ToList() query duration: {0}", timer.Elapsed);

                timer.Restart();
                CorrectToListUse(context);
                Console.WriteLine("Correct use of ToList() query duration: {0}", timer.Elapsed);
            }
/*
+--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
|                    | Run 1 | Run 2 | Run 3 | Run 4 | Run 5 | Run 6 | Run 7 | Run 8 | Run 9 | Run 10 | Average time |
+--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
| Non-optimized (s.) | 0.095 | 0.093 | 0.055 | 0.078 | 0.092 | 0.092 | 0.087 | 0.091 | 0.087 | 0.094  | 0.086        |
| Optimized (s.)     | 0.011 | 0.013 | 0.016 | 0.027 | 0.022 | 0.016 | 0.014 | 0.015 | 0.011 | 0.011  | 0.015        |
+--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
*/
            using (var context = new AdsEntities())
            {
                //Problem 3. Select Everything vs. Select Certain Columns

                //initialize the DB connection in order to measure more accurately
                var adsCount = context.Ads.Count();
                Console.WriteLine(adsCount);

                var timer = new Stopwatch();

                timer.Start();
                //1. Select everything from the Ads table and print only the ad title:
                SelectAllAdColumns(context);
                Console.WriteLine("Select Ad * duration: {0}", timer.Elapsed);

                timer.Restart();

                //2. Select the ad title from Ads table and print it.
                SelectOnlyAdTitle(context);
                Console.WriteLine("Select Ad title duration: {0}", timer.Elapsed);
            }
/*
+--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
|                    | Run 1 | Run 2 | Run 3 | Run 4 | Run 5 | Run 6 | Run 7 | Run 8 | Run 9 | Run 10 | Average time |
+--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
| Non-optimized (s.) | 0.095 | 0.091 | 0.090 | 0.088 | 0.092 | 0.092 | 0.089 | 0.091 | 0.088 | 0.094  | 0.092        |
| Optimized (s.)     | 0.015 | 0.012 | 0.11 | 0.012  | 0.015 | 0.016 | 0.014 | 0.015 | 0.015 | 0.015  | 0.015        |
+--------------------+-------+-------+-------+-------+-------+-------+-------+-------+-------+--------+--------------+
*/
        }

        private static void SelectOnlyAdTitle(AdsEntities context)
        {
            var query = @"CHECKPOINT; DBCC DROPCLEANBUFFERS;";
            context.Database.ExecuteSqlCommand(query);

            var ads = context.Ads
                .Select(a => a.Title);
            foreach (var ad in ads)
            {
                Console.WriteLine(ad);
            }
        }

        private static void SelectAllAdColumns(AdsEntities context)
        {
            var query = @"CHECKPOINT; DBCC DROPCLEANBUFFERS;";
            context.Database.ExecuteSqlCommand(query);

            foreach (var ad in context.Ads)
            {
                Console.WriteLine(ad.Title);
            }
        }

        private static void CorrectToListUse(AdsEntities context)
        {
            var query = @"CHECKPOINT; DBCC DROPCLEANBUFFERS;";
            context.Database.ExecuteSqlCommand(query);

            var ads = context.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .Select(a => new
                {
                    a.Title,
                    Category = (a.CategoryId != null) ? a.Category.Name : "no category",
                    Town = (a.TownId != null) ? a.Town.Name : "no town",
                    PublishDate = a.Date
                })
                .OrderBy(a => a.PublishDate)
                .ToList();
        }

        private static void IncorrectToListUse(AdsEntities context)
        {
            var query = @"CHECKPOINT; DBCC DROPCLEANBUFFERS;";
            context.Database.ExecuteSqlCommand(query);

            var ads = context.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .Select(a => new
                {
                    a.Title,
                    Category = (a.CategoryId != null) ? a.Category.Name : "no category",
                    Town = (a.TownId != null) ? a.Town.Name : "no town",
                    PublishDate = a.Date
                })
                .ToList()
                .OrderBy(a => a.PublishDate);
        }
    }
}