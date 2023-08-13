using Application.Services.ImageService;
using Infrastructure.Adapters.ImageService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) 
        { 
            services.AddScoped<ImageServiceBase,CloudinaryImageServiceAdapter>();
            return services;
        }
    }
}
