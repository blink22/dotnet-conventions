using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace WebApi.Extensions
{
    // Operation filter to handle authorization in Swagger documentation
    public class AuthorizeOperationFilter : IOperationFilter
    {
        // Apply method to apply the filter on the operation
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check if the endpoint does not have AllowAnonymous attribute, then add Unauthorized response
            if (!HasAllowAnonymous(context))
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            }
        }

        // Check if the endpoint has AllowAnonymous attribute
        private static bool HasAllowAnonymous(OperationFilterContext context)
        {
            var classAttributes = context.MethodInfo.DeclaringType!.GetCustomAttributes(true);
            var methodAttributes = context.MethodInfo.GetCustomAttributes(true);
            return classAttributes.Union(methodAttributes).OfType<AllowAnonymousAttribute>().Any();
        }
    }

    // Extension class for configuring Swagger
    public static class SwaggerExtensions
    {
        // Method to configure Swagger
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                // Swagger document settings
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Blink22 DotNet Template API",
                    Description = "ASP.Net Core API for Blink22 DotNet Template",
                    Version = "v1"
                });

                // Include XML comments for Swagger documentation
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                // Add security definition for JWT Bearer token
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter the JWT with Bearer into field, e.g., 'Bearer token'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Add security requirement for JWT Bearer token
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                };
                options.AddSecurityRequirement(securityRequirement);

                // Add operation filter for authorization
                options.OperationFilter<AuthorizeOperationFilter>();
            });

            return services; // Returning the updated IServiceCollection
        }
    }
}
