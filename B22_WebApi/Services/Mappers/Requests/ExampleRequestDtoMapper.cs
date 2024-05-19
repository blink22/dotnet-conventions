using Core.Entities;
using Services.DTOs.Requests;

namespace Services.Mappers.Requests
{
    // Mapper class to map ExampleRequestDto to ExampleEntity
    public static class ExampleRequestDtoMapper
    {
        // Method to map ExampleRequestDto to ExampleEntity
        public static ExampleEntity MapToExampleEntityEntity(this ExampleRequestDto dto)
        {
            // Checking if dto is null
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto)); // Throwing ArgumentNullException if dto is null
            }

            // Creating a new ExampleEntity object and initializing its properties from dto
            var exampleEntity = new ExampleEntity()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            return exampleEntity; // Returning the mapped ExampleEntity
        }
    }
}
