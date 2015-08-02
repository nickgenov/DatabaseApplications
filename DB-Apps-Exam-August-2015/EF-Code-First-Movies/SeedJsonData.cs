using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;

namespace EF_Code_First_Movies
{
    using Enums;
    using Models;
    using Newtonsoft.Json.Linq;


    class SeedJsonData
    {
        static void Main()
        {
            var context = new MoviesModel();

            string jsonCountries = File.ReadAllText("../../countries.json");
            SeedCountries(jsonCountries, context);

            string jsonUsers = File.ReadAllText("../../users.json");
            SeedUsers(jsonUsers, context);

            string jsonMovies = File.ReadAllText("../../movies.json");
            SeedMovies(jsonMovies, context);

            string jsonRatings = File.ReadAllText("../../movie-ratings.json");
            SeedRatings(jsonRatings, context);

            string jsonFavouriteMovies = File.ReadAllText("../../users-and-favourite-movies.json");
            SeedFavouriteMovies(jsonFavouriteMovies, context);
        }

        private static void SeedFavouriteMovies(string jsonFavouriteMovies, MoviesModel context)
        {
            var userMovies = JArray.Parse(jsonFavouriteMovies);
            foreach (JToken userMovie in userMovies)
            {
                string user = userMovie["username"].ToString();
                var dbUser = context.Users.FirstOrDefault(u => u.Username == user);

                foreach (var favourite in userMovie["favouriteMovies"])
                {
                    string fv = favourite.ToString();
                    var dbMovie = context.Movies.FirstOrDefault(m => m.Isbn == fv);

                    dbUser.Movies.Add(dbMovie);
                }
            }
            context.SaveChanges();
        }

        private static void SeedRatings(string jsonRatings, MoviesModel context)
        {
            var ratings = JArray.Parse(jsonRatings);
            foreach (JToken rating in ratings)
            {
                string isbn = rating["movie"].ToString();
                string user = rating["user"].ToString();

                int movieId = context.Movies.FirstOrDefault(m => m.Isbn == isbn).Id;
                int userId = context.Users.FirstOrDefault(u => u.Username == user).Id;

                Rating dbRating = new Rating()
                {
                    MovieId = movieId,
                    UserId = userId,
                    Stars = int.Parse(rating["rating"].ToString())
                };
                context.Ratings.Add(dbRating);
            }
            context.SaveChanges();
        }

        private static void SeedMovies(string jsonMovies, MoviesModel context)
        {
            var movies = JArray.Parse(jsonMovies);
            foreach (JToken movie in movies)
            {
                AgeRestriction movieRestriction;
                if (movie["ageRestriction"].ToString() == "0")
                {
                    movieRestriction = AgeRestriction.Child;
                }
                else if (movie["ageRestriction"].ToString() == "1")
                {
                    movieRestriction = AgeRestriction.Teen;
                }
                else
                {
                    movieRestriction = AgeRestriction.Adult;
                }

                Movie dbMovie = new Movie()
                {
                    Title = movie["title"].ToString(),
                    Isbn = movie["isbn"].ToString(),
                    AgeRestriction = movieRestriction,
                };
                context.Movies.Add(dbMovie);
            }
            context.SaveChanges();
        }

        private static void SeedCountries(string jsonCountries, MoviesModel context)
        {
            var countries = JArray.Parse(jsonCountries);
            foreach (JToken country in countries)
            {
                Country dbCountry = new Country()
                {
                    Name = country["name"].ToString()
                };
                context.Countries.Add(dbCountry);
            }
            context.SaveChanges();
        }

        private static void SeedUsers(string jsonUsers, MoviesModel context)
        {
            var users = JArray.Parse(jsonUsers);
            foreach (JToken user in users)
            {
                string age = null;
                if (user["age"] != null)
                {
                    age = user["age"].ToString();
                }

                User dbUser = new User()
                {
                    Username = user["username"].ToString(),
                    Age = age,
                    Email = user["email"].ToString()
                };
                context.Users.Add(dbUser);
            }
            context.SaveChanges();
        }
    }
}