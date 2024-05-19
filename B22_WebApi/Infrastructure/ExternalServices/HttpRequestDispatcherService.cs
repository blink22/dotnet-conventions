using Core.Contracts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ExternalServices
{
    // Example service for making HTTP requests
    public class HttpRequestDispatcherService : IHttpRequestDispatcher
    {
        private readonly string _envVariable; // Environment variable
        private readonly ILogger<HttpRequestDispatcherService> _logger; // Logger

        // Constructor to initialize the service with logger
        public HttpRequestDispatcherService(ILogger<HttpRequestDispatcherService> logger)
        {
            // Getting environment variable value
            _envVariable = Environment.GetEnvironmentVariable("ENV_VAR_NAME");

            _logger = logger; // Initializing logger
        }

        // Method to send a DELETE HTTP request asynchronously
        public Task<HttpResponseMessage> DeleteAsync(string url)
        {
            throw new NotImplementedException(); // Implementation pending
        }

        // Method to dispose resources
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        // Method to send a GET HTTP request asynchronously
        public Task<HttpResponseMessage> GetAsync(string url)
        {
            throw new NotImplementedException();
        }

        // Method to send a POST HTTP request asynchronously
        public Task<HttpResponseMessage> PostAsync(string url, object data)
        {
            throw new NotImplementedException(); 
        }

        // Method to send a PUT HTTP request asynchronously
        public Task<HttpResponseMessage> PutAsync(string url, object data)
        {
            throw new NotImplementedException();
        }
    }
}
