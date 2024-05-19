using Core.Repositories;

namespace Infrastructure.DataAccess
{
    // Class representing a unit of work implementations for database operations
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context; // Database context
        private IExampleRepository _exampleRepository; // Repository for Example entity

        // Constructor to initialize the unit of work with the database context
        public UnitOfWork(AppDbContext context)
        {
            _context = context; // Initializing database context
            _exampleRepository = new ExampleRepository(_context); // Initializing Example repository with context
        }

        // Property to access Example repository
        public IExampleRepository ExampleRepository => _exampleRepository;

        // Method to commit changes asynchronously
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync(); // Saving changes to the database and returning the number of affected entries
        }

        // Method to dispose of the database context
        public void Dispose()
        {
            _context.Dispose(); // Disposing of the database context
        }
    }
}
