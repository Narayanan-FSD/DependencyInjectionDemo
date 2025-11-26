using DependencyInjectionDemo.BusinessLayer;
using DependencyInjectionDemo.DataAccessLayer;
using DependencyInjectionDemo.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionDemo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataAccessService, DataAccessService>();
            services.AddSingleton<IBusinessService, BusinessService>();

            services.Configure<Constants>(configuration.GetSection("Constants"));

            return services;
        }
    }
}
