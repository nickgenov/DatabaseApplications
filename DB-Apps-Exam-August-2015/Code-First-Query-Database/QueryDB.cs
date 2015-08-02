using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using EF_Code_First_Movies;
using EF_Code_First_Movies.Enums;

namespace Code_First_Query_Database
{
    class QueryDb
    {
        static void Main()
        {
            var context = new MoviesModel();

            //1. Adult Movies
            var adultMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Adult)
                .Select(m => new
                {
                    title = m.Title,
                    ratingsGiven = m.Ratings.Count()
                })
                .ToList();

            var jsonAdultMovies = new JavaScriptSerializer().Serialize(adultMovies);
            File.WriteAllText("../../adult-movies.json", jsonAdultMovies);


            //2. Rated Movies by User
            var ratedMoviesByUser = context.Users
                .Where(u => u.Username == "pmoore0")
                .Select(u => new
                {
                    u.Id,
                    username = u.Username,
                    ratedMovies = u.Movies
                        .Select(m => new
                        {
                            title = m.Title,
                            //USER RATING IS WRONG, fix it!
                            userRating = m.Ratings.Where(r => r.UserId == u.Id)
                                .Select(r => r.Stars),
                            averageRating = m.Ratings.Average(r => r.Stars)
                        })
                        .OrderBy(m => m.title)
                })
                .ToList();

            var jsonRatedMovies = new JavaScriptSerializer().Serialize(ratedMoviesByUser);
            File.WriteAllText("../../rated-movies.json", jsonRatedMovies);

            //3. Top 10 Favourite Movies

            var favouriteMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Teen)
                .Select(m => new
                {
                    isbn = m.Isbn,
                    title = m.Title,
                    favouritedBy = m.Users
                        .Select(u => u.Username)
                })
                .OrderByDescending(m => m.favouritedBy.Count())
                .ThenBy(m => m.title)
                .Take(10)
                .ToList();

            var jsonFavouriteMovies = new JavaScriptSerializer().Serialize(favouriteMovies);
            File.WriteAllText("../../top-10-favourite-movies.json", jsonFavouriteMovies);
        }
    }
}