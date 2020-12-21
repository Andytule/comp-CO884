using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date Seen")]
        public DateTime? DateSeen { get; set; }

        // Navigation property
        [ForeignKey("Genre")]
        public int? GenreId { get; set; }

        // Navigation property
        public Genre Genre { get; set; }

        [Range(1, 10)]
        public int? Rating { get; set; }

        [Display(Name = "Release Year")]
        public int? ReleaseYear { get; set; }
    }
}
