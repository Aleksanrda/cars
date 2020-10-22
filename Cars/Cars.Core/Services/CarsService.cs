using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.Entities;
using Cars.Core.Repositories;

namespace Cars.Core.Services
{
    public class CarsService : ICarsService
    {
        private readonly ICarRepository _carRepository;

        public CarsService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            var newCar = await _carRepository.AddCarAsync(car);

            return newCar;
        }

        public async Task<Car> DeleteCarAsync(string carId)
        {
            var response = await _carRepository.DeleteCarAsync(carId);

            return response;
        }

        public async Task<Car> GetCarAsync(string carId)
        {
            var car = await _carRepository.GetCarAsync(carId);

            return car;
        }

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            var cars = await _carRepository.GetCarsAsync();

            return cars;
        }

        public async Task<Car> UpdateCarAsync(string carId, Car car)
        {
            var editCar = await _carRepository.UpdateCarAsync(carId, car);

            return editCar;
        }
    }
}
