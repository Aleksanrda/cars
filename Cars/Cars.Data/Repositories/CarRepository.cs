﻿using System;
using Cars.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Cars.Core.Repositories;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Cars.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly Container _container;

        public CarRepository(Container container)
        {
            _container = container;
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            var response = await _container.CreateItemAsync(car, new PartitionKey(car.Id));

            return response.Resource;
        }

        public async Task<Car> DeleteCarAsync(string carId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<Car>(carId, new PartitionKey(carId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
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

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            var query = _container.GetItemLinqQueryable<Car>();
            var iterator = query.ToFeedIterator();

            List<Car> cars = new List<Car>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();

                cars.AddRange(response.ToList());
            }

            return cars;
        }

        public async Task<Car> UpdateCarAsync(string carId, Car car)
        {
            try
            {
                var response = await _container.UpsertItemAsync(car, new PartitionKey(carId));

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }
        }
    }
}
