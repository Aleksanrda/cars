using System;
using Cars.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Cars.Core.Repositories;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Cars.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly Container _container;

        public CarRepository(CosmosClient dbClient, 
            string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            car.Id = Guid.NewGuid().ToString();

            var response = await _container.CreateItemAsync(car, new PartitionKey(car.Id));

            return response.Resource;
        }

        public async Task DeleteCarAsync(string carId)
        {
            await _container.DeleteItemAsync<Car>(carId, new PartitionKey(carId));
        }

        public async Task<Car> GetCarAsync(string carId)
        {
            try
            {
                ItemResponse<Car> response = await _container.ReadItemAsync<Car>(carId, new PartitionKey(carId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Car>> GetCarsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<Car>(new QueryDefinition(queryString));
            List<Car> cars = new List<Car>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                cars.AddRange(response.ToList());
            }

            return cars;
        }

        public async Task<Car> UpdateCarAsync(string carId, Car car)
        {
            var response = await _container.UpsertItemAsync(car, new PartitionKey(carId));

            return response.Resource;
        }
    }
}
