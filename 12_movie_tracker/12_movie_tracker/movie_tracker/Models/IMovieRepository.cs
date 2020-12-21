using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace movie_tracker.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();

        Movie GetMovie(int id);

        void CreateMovie(Movie movie);

        void EditMovie(Movie movie);

        void DeleteMovie(int id);

        IEnumerable<Genre> GetGenres() { return null; }
    }
}
