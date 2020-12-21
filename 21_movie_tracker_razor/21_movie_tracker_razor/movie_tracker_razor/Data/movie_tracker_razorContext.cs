using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movie_tracker_razor.Models;

namespace movie_tracker_razor.Data
{
    public class movie_tracker_razorContext : DbContext
    {
        public movie_tracker_razorContext (DbContextOptions<movie_tracker_razorContext> options)
            : base(options)
        {
        }

        public DbSet<movie_tracker_razor.Models.Movie> Movie { get; set; }
    }
}
