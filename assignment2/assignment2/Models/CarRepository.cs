using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Models
{
    public class CarRepository : ICarRepository
    {
        private static List<Car> cars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Make = "Honda",
                Model = "Civic",
                Color = "Black",
                Year = 2019,
                PurchaseDate = new DateTime(2019, 12, 22),
                Kilometres = 50000
            },
            new Car
            {
                Id = 2,
                Make = "Toyota",
                Model = "Corolla",
                Color = "White",
                Year = 2015,
                PurchaseDate = new DateTime(2017, 3, 15),
                Kilometres = 300000
            },
            new Car
            {
                Id = 3,
                Make = "Tesla",
                Model = "Model S",
                Color = "Space Gray",
                Year = 2020,
                PurchaseDate = new DateTime(2020, 1, 29),
                Kilometres = 100000
            }
        };

        public void CreateCar(Car car)
        {
            var maxId = 0;

            if (cars.Count != 0)
            {
                maxId = cars.Max(c => c.Id);
            }

            car.Id = maxId + 1;
            cars.Add(car);
        }

        public void DeleteCar(int id)
        {
            var index = cars.FindIndex(c => c.Id == id);
            cars.RemoveAt(index);
        }

        public void EditCar(Car car)
        {
            var index = cars.FindIndex(c => c.Id == car.Id);
            cars[index] = car;
        }

        public Car GetCar(int id)
        {
            return cars.Find(c => c.Id == id);
        }

        public IEnumerable<Car> GetCars()
        {
            return cars;
        }
    }
}
