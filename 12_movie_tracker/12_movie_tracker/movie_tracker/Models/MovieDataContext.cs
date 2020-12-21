using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker.Models
{
    public class MovieDataContext : DbContext, IMovieRepository
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public MovieDataContext(DbContextOptions<MovieDataContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, GenreDescription = "Action" },
                new Genre { Id = 2, GenreDescription = "Adventure" },
                new Genre { Id = 3, GenreDescription = "Animation" },
                new Genre { Id = 4, GenreDescription = "Biography" },
                new Genre { Id = 5, GenreDescription = "Comedy" },
                new Genre { Id = 6, GenreDescription = "Crime" },
                new Genre { Id = 7, GenreDescription = "Documentary" },
                new Genre { Id = 8, GenreDescription = "Drama" },
                new Genre { Id = 9, GenreDescription = "Family" },
                new Genre { Id = 10, GenreDescription = "Fantasy" },
                new Genre { Id = 11, GenreDescription = "Film Noir" },
                new Genre { Id = 12, GenreDescription = "History" },
                new Genre { Id = 13, GenreDescription = "Horror" },
                new Genre { Id = 14, GenreDescription = "Music" },
                new Genre { Id = 15, GenreDescription = "Musical" },
                new Genre { Id = 16, GenreDescription = "Mystery" },
                new Genre { Id = 17, GenreDescription = "Romance" },
                new Genre { Id = 18, GenreDescription = "Sci-Fi" },
                new Genre { Id = 19, GenreDescription = "Short Film" },
                new Genre { Id = 20, GenreDescription = "Sport" },
                new Genre { Id = 21, GenreDescription = "Superhero" },
                new Genre { Id = 22, GenreDescription = "Thriller" },
                new Genre { Id = 23, GenreDescription = "War" },
                new Genre { Id = 24, GenreDescription = "Western" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Avengers: Endgame",
                    DateSeen = new DateTime(2019, 4, 29),
                    GenreId = 1,
                    Rating = 9
                },
                new Movie
                {
                    Id = 2,
                    Title = "Incredibles 2",
                    DateSeen = new DateTime(2018, 6, 19),
                    Rating = 8
                },
                new Movie
                {
                    Id = 3,
                    Title = "Dunkirk",
                    GenreId = 8
                });
        }

        public IEnumerable<Movie> GetMovies()
        {
            return Movies.Include("Genre");
        }

        public Movie GetMovie(int id)
        {
            return Movies.Include("Genre").FirstOrDefault(m => m.Id == id);
        }

        public void CreateMovie(Movie movie)
        {
            Movies.Add(movie);
            SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            Movies.Update(movie);
            SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = GetMovie(id);
            Movies.Remove(movie);
            SaveChanges();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return Genres;
        }
    }
}
