
using Core.Entities;
using Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;


public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    // DbSets refers to table data type and table name, make sure to name tables in plural form
    public DbSet<ExampleEntity>? TableName { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // model builder runs/applies configurations we made in the config class
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleConfigurations).Assembly);
    }

    // overriding SaveChangesAsync to add values for CreatedAt and UpdatedAt
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}