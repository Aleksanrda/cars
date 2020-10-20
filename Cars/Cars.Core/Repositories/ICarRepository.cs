using Cars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCarsAsync();

        Task<Car> GetCarAsync(int carId);

        Task<Car> AddCarAsync(Car car);

        Task UpdateCarAsync(string carId, Car car);

        Task PatchCarAsync(int carId, Car car);

        Task DeleteCarAsync(string carId);
    }
}
