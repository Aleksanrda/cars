using Cars.Core.Entities;
using Cars.Core.Repositories;
using Cars.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Core.Services;

namespace Cars.API
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterCarsServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddScoped<ICarsService, CarsService>();

            return services;
        }
    }
}
