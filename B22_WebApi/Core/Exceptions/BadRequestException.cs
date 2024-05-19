
namespace Core.Exceptions
{
    // Exception Handling Class
    public class BadRequestException : Exception
    {
        public BadRequestException(string message): base(message) { }
    }
}
