using assignment2.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using assignment2.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace assignment2_test
{
    [TestCaseOrderer("assignment2_test.AlphabeticalOrderer", "assignment2_test")]
    public class UnitTest1
    {
        private ICarRepository db;

        public UnitTest1()
        {
            db = new CarRepository();
        }

        [Fact]
        public void A_Index_Cars()
        {
            // Arrange
            var carsController = new CarsController(db);

            // Act
            var actionResult = carsController.Index();

            // Assert
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = actionResult as ViewResult;
            Assert.IsType<List<Car>>(viewResult.Model);
            var cars = viewResult.Model as List<Car>;
            // Check the number of cars and a portion of every record and all fields
            Assert.Equal(3, cars.Count);
            Assert.Equal(1, cars[0].Id);
            Assert.Equal("Toyota", cars[1].Make);
            Assert.Equal("Model S", cars[2].Model);
            Assert.Equal("Black", cars[0].Color);
            Assert.Equal(2015, cars[1].Year);
            Assert.Equal(new DateTime(2020, 1, 29), cars[2].PurchaseDate);
            Assert.Equal(50000, cars[0].Kilometres);
        }

        [Fact]
        public void B_Details_Car()
        {
            // Arrange
            var carsController = new CarsController(db);

            // Act
            var actionResult = carsController.Details(1);

            // Assert
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = actionResult as ViewResult;
            Assert.IsType<Car>(viewResult.Model);
            var car = viewResult.Model as Car;
            // Test all properties
            Assert.Equal(1, car.Id);
            Assert.Equal("Honda", car.Make);
            Assert.Equal("Civic", car.Model);
            Assert.Equal("Black", car.Color);
            Assert.Equal(2019, car.Year);
            Assert.Equal(new DateTime(2019, 12, 22), car.PurchaseDate);
            Assert.Equal(50000, car.Kilometres);
        }

        [Fact]
        public void C_Create_Car()
        {
            // Arrange
            var carsController = new CarsController(db);

            // Act
            var actionResult = carsController.Create(
                new Car {
                    Make = "Mitsubishi",
                    Model = "Lancer",
                    Color = "Red",
                    Year = 2002,
                    PurchaseDate = new DateTime(2005, 5, 4),
                    Kilometres = 700000
                });

            // Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            var redirectToActionResult = actionResult as RedirectToActionResult;
            Assert.Equal("Index", redirectToActionResult.ActionName);

            actionResult = carsController.Index();
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = actionResult as ViewResult;
            Assert.IsType<List<Car>>(viewResult.Model);
            var cars = viewResult.Model as List<Car>;
            Assert.Equal(4, cars.Count);
        }

        [Fact]
        public void D_Edit_Car()
        {
            // Arrange
            var carsController = new CarsController(db);

            // Act
            var actionResult = carsController.Edit(1,
                new Car
                {
                    Id = 1,
                    Make = "Honda",
                    Model = "Accord",
                    Color = "Navy",
                    Year = 2019,
                    PurchaseDate = new DateTime(2019, 12, 22),
                    Kilometres = 50000
                });

            // Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            var redirectToActionResult = actionResult as RedirectToActionResult;
            Assert.Equal("Index", redirectToActionResult.ActionName);

            actionResult = carsController.Details(1);
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = actionResult as ViewResult;
            Assert.IsType<Car>(viewResult.Model);
            var car = viewResult.Model as Car;
            Assert.Equal("Honda", car.Make);
            Assert.Equal("Navy", car.Color);

            
        }

        [Fact]
        public void E_Delete_Car()
        {
            // Arrange
            var carsController = new CarsController(db);

            // Act
            var actionResult = carsController.Delete(1, null);

            // Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            var redirectToActionResult = actionResult as RedirectToActionResult;
            Assert.Equal("Index", redirectToActionResult.ActionName);

            actionResult = carsController.Index();
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = actionResult as ViewResult;
            Assert.IsType<List<Car>>(viewResult.Model);
            var cars = viewResult.Model as List<Car>;
            Assert.Equal(3, cars.Count);
        }
    }
}
