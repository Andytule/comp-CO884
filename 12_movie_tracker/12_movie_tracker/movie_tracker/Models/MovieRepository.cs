using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_tracker.Models
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Avengers: Endgame",
                DateSeen = new DateTime(2019, 4, 29),
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
                Title = "Dunkirk"
            }
        };

        public void CreateMovie(Movie movie)
        {
            var maxId = 0;

            if (movies.Count != 0)
            {
                maxId = movies.Max(movies => movies.Id);
            }

            movie.Id = maxId + 1;
            movies.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            var index = movies.FindIndex(m => m.Id == id);
            movies.RemoveAt(index);
        }

        public void EditMovie(Movie movie)
        {
            var index = movies.FindIndex(m => m.Id == movie.Id);
            movies[index] = movie;
        }

        public Movie GetMovie(int id)
        {
            return movies.Find(m => m.Id == id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }
    }
}
