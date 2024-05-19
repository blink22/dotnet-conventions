using Core.Repositories;
using Infrastructure.DataAccess;
using Services.Implementations;
using Services.Interfaces;

namespace WebApi.Extensions
{
    // Extension class for adding services to IServiceCollection
    public static class ServicesExtension
    {
        // Extension method to add services to IServiceCollection
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Adding scoped services: IUnitOfWork and its implementation UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Adding scoped services: IExampleService and its implementation ExampleService
            services.AddScoped<IExampleService, ExampleService>();

            return services; // Returning the updated IServiceCollection
        }
    }
}
