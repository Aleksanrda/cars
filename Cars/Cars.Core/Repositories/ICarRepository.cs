using Cars.Core.Entities;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Core.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCarsAsync();

        Task<Car> GetCarAsync(string carId);

        Task<Car> AddCarAsync(Car car);

        Task<Car> UpdateCarAsync(string carId, Car car);

        Task<Car> DeleteCarAsync(string carId);
    }
}
