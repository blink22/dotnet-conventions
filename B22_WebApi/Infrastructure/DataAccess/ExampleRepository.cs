using Core.Entities;
using Core.Repositories;

namespace Infrastructure.DataAccess
{
    // Repository implementation for ExampleEntity
    public class ExampleRepository : GenericRepository<ExampleEntity>, IExampleRepository
    {
        // Constructor to initialize the repository with the database context
        public ExampleRepository(AppDbContext context) : base(context)
        {
            // Constructor chaining to the base class constructor
        }
    }
}
