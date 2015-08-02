using System.Collections.Generic;

namespace EF_Code_First_Movies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Movie> movies;
        private ICollection<Rating> ratings;

        public User()
        {
            this.movies = new HashSet<Movie>();
            this.ratings = new HashSet<Rating>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        public string Email { get; set; }
        public string Age { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}