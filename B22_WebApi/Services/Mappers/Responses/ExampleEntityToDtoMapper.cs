using Core.Entities;
using Services.DTOs.Responses;

namespace Services.Mappers.Responses
{
    // Mapper class to map ExampleEntity to ExampleResponseDto
    public static class ExampleEntityToDtoMapper
    {
        // Method to map ExampleEntity to ExampleResponseDto
        public static ExampleResponseDto MapToExampleEntityDto(this ExampleEntity exampleEntity)
        {
            // Creating and returning a new ExampleResponseDto object, initialized with data from ExampleEntity
            return new ExampleResponseDto()
            {
                Id = exampleEntity.Id, // Mapping Id
                FirstName = exampleEntity.FirstName, // Mapping FirstName
                LastName = exampleEntity.LastName, // Mapping LastName
                CreatedAt = exampleEntity.CreatedAt.ToString(), // Mapping CreatedAt as string
                UpdatedAt = exampleEntity.UpdatedAt.ToString(), // Mapping UpdatedAt as string
            };
        }
    }
}
