// Middleware class for handling exceptions in the ASP.NET Core pipeline
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        // Constructor to initialize the middleware
        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Method to handle exceptions asynchronously
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception, "Exception occurred: {Message}", exception.Message);

                // Handle the exception
                await HandleExceptionAsync(context, exception);
            }
        }

        // Method to handle exceptions and return appropriate HTTP responses
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Determine the status code based on the type of exception
            var statusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = "application/json";

            // Create a ProblemDetails object to return as response
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Detail = exception.Message
            };

            context.Response.StatusCode = statusCode;

            // Serialize and write the ProblemDetails object as JSON response
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
