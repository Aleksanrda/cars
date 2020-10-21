using Cars.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Core.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCarsAsync(string query);

        Task<Car> GetCarAsync(string carId);

        Task AddCarAsync(Car car);

        Task UpdateCarAsync(string carId, Car car);

        Task DeleteCarAsync(string carId);
    }
}
