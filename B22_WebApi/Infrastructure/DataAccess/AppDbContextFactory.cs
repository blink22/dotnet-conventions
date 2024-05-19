using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess
{
    // Factory class used for injecting application context in CI/CD flows, returns a new working DBContext
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        // Method to create a new instance of the application database context
        public AppDbContext CreateDbContext(string[] args)
        {
            // Building configuration from appsettings.json and environment variables
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Setting base path for configuration
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // Adding appsettings.json file
                .AddEnvironmentVariables()
                .Build(); // Building configuration

            // Retrieving connection string from configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Creating options builder for the database context
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Configuring options builder to use SQL Server with the retrieved connection string
            optionsBuilder.UseSqlServer(connectionString);

            // Returning a new instance of the application database context with the configured options
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
