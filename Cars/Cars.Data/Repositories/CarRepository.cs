using Cars.Core.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cars.Core.Repositories;
using System.Threading.Tasks;

namespace Cars.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> _cars;

        public CarRepository()
        {
            _cars = new List<Car>()
            {
                new Car {Id = 1, Name = "Audi", Volume = 2.6, Consumption = 344.6, Capacity = 34567, Price = 123333333},
                new Car {Id = 2, Name = "BMW", Volume = 0.5, Consumption = 545.78, Capacity = 98844, Price = 2333444},
                new Car {Id = 3, Name = "Ferrari", Volume = 4.7, Consumption = 234.4, Capacity = 34324, Price = 3445}
            };
        }

        public void AddCar(PostCarDTO car)
        {
            _cars.Add(new Car()
            {
                Id = 4,
                Name = car.Name,
                Volume = car.Volume,
                Consumption = car.Consumption,
                Price = car.Price
            });
        }

        public bool DeleteCar(int carId)
        {
            var carToRemove = _cars.SingleOrDefault(c => c.Id == carId);

            if (carToRemove != null)
            {
                _cars.Remove(carToRemove);

                return true;
            }

            return false;
        }

        public Car GetCar(int carId)
        {
            return _cars.FirstOrDefault(с => с.Id == carId);
        }

        public IEnumerable<Car> GetCars()
        {
            return _cars.OrderBy(с => с.Name);
        }

        public Car PatchCar(int carId)
        {
            var carToPatch = _cars.FirstOrDefault(c => c.Id == carId);

            return carToPatch;
        }

        public Car UpdateCar(int carId, Car car)
        {
            var currentCar = _cars.FirstOrDefault(c => c.Id == carId); ;

            if (currentCar != null)
            {
                currentCar.Name = car.Name;
                currentCar.Volume = car.Volume;
                currentCar.Consumption = car.Consumption;
                currentCar.Capacity = car.Capacity;
                currentCar.Price = car.Price;
            }

            return currentCar;
        }
    }
}
