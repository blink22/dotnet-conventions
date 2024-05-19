using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    // Extension class for configuring the database context
    public static class DatabaseContextExtensions
    {
        // Extension method to configure the database context
        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Adding the AppDbContext to the services with the specified SQL Server connection string
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services; // Returning the updated IServiceCollection
        }
    }
}
