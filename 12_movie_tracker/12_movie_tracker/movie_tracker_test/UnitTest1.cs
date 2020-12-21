using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using movie_tracker.Controllers;
using movie_tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace movie_tracker_test
{
    [TestCaseOrderer("movie_tracker_test.AlphabeticalOrderer", "movie_tracker_test")]
    public class UnitTest1
    {
        private MovieDataContext db;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<MovieDataContext>().UseInMemoryDatabase(databaseName: "movie_tests").Options;
            db = new MovieDataContext(options);

            db.Movies.AddRange(
                new Movie
                {
                    Title = "The Dark Knight",
                    DateSeen = new DateTime(2020, 5, 20),
                    GenreId = 1,
                    Rating = 9
                },
                new Movie
                {
                    Title = "Always Be My Maybe",
                    DateSeen = new DateTime(2020, 7, 22),
                    GenreId = 5,
                    Rating = 7
                });

            db.SaveChanges();
        }

        [Fact]
        public void A_Index_NoInput_ReturnsMovies()
        {
            // Arrange
            var moviesController = new MoviesController(db);

            // Act
            var actionResult = moviesController.Index();

            // Assert
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = actionResult as ViewResult;
            Assert.IsType<InternalDbSet<Movie>>(viewResult.Model);
            var dbMovies = viewResult.Model as InternalDbSet<Movie>;
            var movies = dbMovies.ToList();
            // Check the number of movies and a portion of every record and all fields
            Assert.Equal(2, movies.Count);
            Assert.Equal(1, movies[0].Id);
            Assert.Equal("Always Be My Maybe", movies[1].Title);
            Assert.Equal(new DateTime(2020, 5, 20), movies[0].DateSeen);
            Assert.Equal(5, movies[1].GenreId);
            Assert.Equal(9, movies[0].Rating);
        }

        [Fact]
        public void B_Details_MovieId_ReturnsMovie()
        {
            // Arrange
            var moviesController = new MoviesController(db);

            // Act
            var actionResult = moviesController.Details(2);

            // Assert
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = actionResult as ViewResult;
            Assert.IsType<Movie>(viewResult.Model);
            var movie = viewResult.Model as Movie;
            // Test all properties
            Assert.Equal(2, movie.Id);
            Assert.Equal("Always Be My Maybe", movie.Title);
            Assert.Equal(new DateTime(2020, 7, 22), movie.DateSeen);
            Assert.Equal(5, movie.GenreId);
            Assert.Equal(7, movie.Rating);
        }

        [Fact]
        public void C_Create_Movie_RedirectsToIndex()
        {
            // Arrange
            var moviesController = new MoviesController(db);

            // Act
            var actionResult = moviesController.Create(
                new Movie
                {
                    Title = "Casablanca",
                    DateSeen = DateTime.Now.Date,
                    GenreId = 8,
                    Rating = 9
                });

            // Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            var redirectToActionResult = actionResult as RedirectToActionResult;
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
