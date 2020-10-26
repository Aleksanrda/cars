using System;
using System.Collections.Generic;
using System.Text;
using Cars.Core.Repositories;
using Microsoft.Azure.Cosmos;

namespace Cars.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Container _container;
        private ICarRepository _cars;

        public UnitOfWork(CosmosClient dbClient, 
            string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public ICarRepository Cars
        {
            get
            {
                return _cars ??
                       (_cars = new CarRepository(_container));
            }
        }

    }
}
