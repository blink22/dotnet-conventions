
namespace Core.Entities
{
    // The Entity inherits id, createdAt and UpdatedAt from the base entity
    public class ExampleEntity : BaseEntity
    {
        // Example Properties with default values
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
