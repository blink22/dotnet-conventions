using WebApi.Extensions; // Import custom extension methods for configuring services
using WebApi.Middlewares; // Import custom middleware for exception handling

var builder = WebApplication.CreateBuilder(args); // Create a new web application builder

// Add configuration sources to the application configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); // Load configuration from environment variables

var configuration = builder.Configuration; // Get the configuration from the builder

// Add services to the service container
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}); // Configure controllers and JSON serialization settings

builder.Services.ConfigureSwagger() // Configure Swagger documentation
                .ConfigureCors() // Configure Cross-Origin Resource Sharing (CORS) policy
                .AddServices() // Add custom services to the service container
                .ConfigureDatabaseContext(configuration); // Configure database context using the provided configuration

var app = builder.Build(); // Build the web application

// Configure the HTTP request pipeline

if (!app.Environment.IsProduction())
{
    app.UseStaticFiles(); // Enable serving static files (only in non-production environment)
    app.UseSwagger(); // Enable Swagger middleware for API documentation
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Blink22 WebApi Template v1"); // Configure Swagger UI endpoint
        options.RoutePrefix = string.Empty; // Set Swagger UI route prefix
        options.EnablePersistAuthorization(); // Enable persisting authorization between requests
    });
}

app.UseRouting(); // Enable routing middleware for handling HTTP requests

app.UseCors("AllowAll"); // Enable CORS middleware with the specified policy

app.UseHttpsRedirection(); // Enable HTTPS redirection middleware

app.UseAuthentication(); // Enable authentication middleware

app.UseAuthorization(); // Enable authorization middleware

app.UseMiddleware<ExceptionHandlingMiddleware>(); // Enable custom exception handling middleware

app.MapControllers(); // Map controller routes

app.Run(); // Start the application
