namespace WebApi.Extensions
{
    // Extension class for configuring CORS (Cross-Origin Resource Sharing)
    public static class CorsExtensions
    {
        // Extension method to configure CORS
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            // Adding CORS policy named "AllowAll"
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin() // Allowing requests from any origin
                           .AllowAnyMethod() // Allowing requests with any HTTP method
                           .AllowAnyHeader()); // Allowing requests with any HTTP headers
            });

            return services; // Returning the updated IServiceCollection
        }
    }
}
