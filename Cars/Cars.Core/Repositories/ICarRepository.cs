using Cars.Core.Entities;
using Cars.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();

        Car GetCar(int carId);

        void AddCar(CarViewModel car);

        Car  UpdateCar(int carId, Car car);

        Car PatchCar(int carId);

        bool DeleteCar(int carId);
    }
}
