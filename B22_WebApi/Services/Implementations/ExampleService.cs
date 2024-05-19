using Core.Entities;
using Core.Repositories;
using Services.Interfaces;

namespace Services.Implementations
{
    // Implementation of IExampleService interface
    public class ExampleService : IExampleService
    {
        private readonly IUnitOfWork _unitOfWork; // Unit of work for database operations

        // Constructor to initialize the service with unit of work
        public ExampleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; // Initializing unit of work
        }

        // Method to get an ExampleEntity by its id asynchronously
        public async Task<ExampleEntity> GetExampleEntityByIdAsync(Guid id)
        {
            return await _unitOfWork.ExampleRepository.GetByIdAsync(id); // Using repository method to get ExampleEntity by id
        }

        // Method to get all ExampleEntities asynchronously
        public async Task<ExampleEntity[]> GetAllExampleEntitiesAsync()
        {
            var ExampleEntitys = await _unitOfWork.ExampleRepository.GetAllAsync(); // Retrieving all ExampleEntities
            return ExampleEntitys.ToArray(); // Converting to array and returning
        }

        // Method to create an ExampleEntity asynchronously
        public async Task<ExampleEntity> CreateExampleEntityAsync(string firstName, string lastName)
        {
            var ExampleEntity = new ExampleEntity()
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FirstName = firstName,
                LastName = lastName,
            };

            await _unitOfWork.ExampleRepository.CreateAsync(ExampleEntity); // Adding ExampleEntity to repository
            await _unitOfWork.CommitAsync(); // Saving changes to the database

            return ExampleEntity; // Returning the created ExampleEntity
        }

        // Method to delete an ExampleEntity by its id asynchronously
        public async Task DeleteExampleEntityAsync(Guid id)
        {
            await _unitOfWork.ExampleRepository.DeleteAsync(id); // Deleting ExampleEntity by id
            await _unitOfWork.CommitAsync(); // Saving changes to the database
        }

        // Method to update an ExampleEntity asynchronously
        public async Task UpdateExampleEntityAsync(ExampleEntity ExampleEntity)
        {
            _unitOfWork.ExampleRepository.Update(ExampleEntity); // Updating ExampleEntity
            await _unitOfWork.CommitAsync(); // Saving changes to the database
        }

        // Method to get an ExampleEntity by its name asynchronously
        public async Task<ExampleEntity> GetExampleEntityByNameAsync(string firstName)
        {
            var ExampleEntity = await _unitOfWork.ExampleRepository.FindAsync(ExampleEntity => ExampleEntity.FirstName == firstName); // Finding ExampleEntity by name
            return ExampleEntity.FirstOrDefault(); // Returning the found ExampleEntity
        }
    }
}
