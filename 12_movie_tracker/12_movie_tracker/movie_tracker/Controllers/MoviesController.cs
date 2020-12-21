using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using movie_tracker.Models;

namespace movie_tracker.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieRepository db;

        public MoviesController(IMovieRepository movieRepository):base()
        {
            db = movieRepository;
        }

        // GET: MoviesController
        public ActionResult Index()
        {
            return View(db.GetMovies());
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var movie = db.GetMovie(id);

            if (movie == null)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = id.ToString(),
                        Description = $"Unable to find movie with id={id}."
                    });
            }

            return View(movie);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.GetGenres(), "Id", "GenreDescription");
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CreateMovie(movie);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(movie);
                }
            }
            catch (Exception ex)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = "0",
                        Description = $"Exception message: {ex.Message}."
                    });
            }
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = db.GetMovie(id);

            if (movie == null)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = id.ToString(),
                        Description = $"Unable to find movie with id={id}."
                    });
            }

            ViewBag.GenreId = new SelectList(db.GetGenres(), "Id", "GenreDescription");
            return View(movie);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.EditMovie(movie);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(movie);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = db.GetMovie(id);

            if (movie == null)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = id.ToString(),
                        Description = $"Unable to find movie with id={id}."
                    });
            }

            return View(movie);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                db.DeleteMovie(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
