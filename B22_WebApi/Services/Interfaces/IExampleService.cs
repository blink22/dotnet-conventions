using Core.Entities;

namespace Services.Interfaces
{
    // Interface for Example service
    public interface IExampleService
    {
        // Method to get an ExampleEntity by its id asynchronously
        Task<ExampleEntity> GetExampleEntityByIdAsync(Guid id);

        // Method to get all ExampleEntities asynchronously
        Task<ExampleEntity[]> GetAllExampleEntitiesAsync();

        // Method to create an ExampleEntity asynchronously
        Task<ExampleEntity> CreateExampleEntityAsync(string firstName, string lastName);

        // Method to delete an ExampleEntity by its id asynchronously
        Task DeleteExampleEntityAsync(Guid id);

        // Method to update an ExampleEntity asynchronously
        Task UpdateExampleEntityAsync(ExampleEntity exampleEntity);

        // Method to get an ExampleEntity by its name asynchronously
        Task<ExampleEntity> GetExampleEntityByNameAsync(string firstName);
    }
}
