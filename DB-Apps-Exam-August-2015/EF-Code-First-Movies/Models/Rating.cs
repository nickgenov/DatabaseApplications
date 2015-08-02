using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First_Movies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 10, ErrorMessage = "Ratings must be between 0 and 10")]
        public int Stars { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}