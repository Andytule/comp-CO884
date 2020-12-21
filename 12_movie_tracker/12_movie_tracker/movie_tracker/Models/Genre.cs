using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        public string GenreDescription { get; set; }

        // Navigation property
        public virtual List<Movie> Movies { get; set; }
    }
}
