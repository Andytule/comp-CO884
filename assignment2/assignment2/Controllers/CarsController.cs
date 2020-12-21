using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository db;

        public CarsController(ICarRepository carRepository) : base()
        {
            db = carRepository;
        }

        // GET: CarsController
        public ActionResult Index()
        {
            return View(db.GetCars());
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            var car = db.GetCar(id);

            if (car == null)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = id.ToString(),
                        Description = $"Unable to find movie with id={id}."
                    });
            }
            return View(car);
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CreateCar(car);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(car);
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

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            var car = db.GetCar(id);
            if (car == null)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = id.ToString(),
                        Description = $"Unable to find movie with id={id}."
                    });
            }
            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.EditCar(car);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(car);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int id)
        {
            var car = db.GetCar(id);
            if (car == null)
            {
                return View("Error",
                    new ErrorViewModel
                    {
                        RequestId = id.ToString(),
                        Description = $"Unable to find movie with id={id}."
                    });
            }
            return View(car);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                db.DeleteCar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
