using movie_tracker_razor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker_razor.Models
{
    public static class SeedData
    {
        public static void Initialize(movie_tracker_razorContext context)
        {
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    DateSeen = DateTime.Now.AddDays(-150),
                    Genre = "Drama",
                    Rating = 8,
                    ImageFile = "shawshank.jpg"
                },
                new Movie
                {
                    Title = "Men In Black",
                    DateSeen = DateTime.Now.AddDays(-250),
                    Genre = "Action",
                    Rating = 7,
                    ImageFile = "meninblack.jpg"
                },
                new Movie
                {
                    Title = "The Dark Knight",
                    DateSeen = DateTime.Now.AddDays(-350),
                    Genre = "Action",
                    Rating = 9,
                    ImageFile = "darkknight.jpg"
                },
                new Movie
                {
                    Title = "12 Angry Men",
                    DateSeen = DateTime.Now.AddDays(-450),
                    Genre = "Drama",
                    Rating = 7,
                    ImageFile = "12angrymen.jpg"
                },
                new Movie
                {
                    Title = "Back to the Future",
                    DateSeen = DateTime.Now.AddDays(-550),
                    Genre = "Adventure",
                    Rating = 8,
                    ImageFile = "backtofuture.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}
