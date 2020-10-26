using Cars.Core.Entities;
using Cars.Core.Repositories;
using Cars.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Cars.Core.Services;
using Cars.ViewModel;
using Cars.ViewModel.Validators;
using Cars.ViewModel.ViewModels;
using FluentValidation;

namespace Cars.API.Infrastructure
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
            services.AddTransient<IValidator<UpdatedCarViewModel>, UpdatedCarValidator>();

            return services;
        }
    }
}
