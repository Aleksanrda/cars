using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.Entities;

namespace Cars.Core.Services
{
    public interface ICarsService
    {
        Task<IEnumerable<Car>> GetCarsAsync();

        Task<Car> GetCarAsync(string carId);

        Task<Car> AddCarAsync(Car car);

        Task<Car> UpdateCarAsync(string carId, Car car);

        Task<Car> DeleteCarAsync(string carId);
    }
}
