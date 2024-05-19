namespace Core.Exceptions
{
    // Exception Handling Class
    public class NotFoundException : Exception
    {
       public NotFoundException(string message) :base(message) { }
    }
}
