using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker_razor.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Seen")]
        public DateTime? DateSeen { get; set; }

        public string Genre { get; set; }

        [Range(1, 10)]
        public int? Rating { get; set; }

        [Display(Name = "Image File")]
        public string ImageFile { get; set; }
    }
}
