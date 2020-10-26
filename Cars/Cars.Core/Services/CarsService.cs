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
        private readonly IUnitOfWork _unitOfWork;

        public CarsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            car.Id = Guid.NewGuid().ToString();

            var newCar = await _unitOfWork.Cars.AddCarAsync(car);

            return newCar;
        }

        public async Task<Car> DeleteCarAsync(string carId)
        {
            var response = await _unitOfWork.Cars.DeleteCarAsync(carId);

            return response;
        }

        public async Task<Car> GetCarAsync(string carId)
        {
            var car = await _unitOfWork.Cars.GetCarAsync(carId);

            return car;
        }

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            var cars = await _unitOfWork.Cars.GetCarsAsync();

            return cars;
        }

        public async Task<Car> UpdateCarAsync(string carId, Car car)
        {
            var editedCar = await _unitOfWork.Cars.UpdateCarAsync(carId, car);

            return editedCar;
        }
    }
}
