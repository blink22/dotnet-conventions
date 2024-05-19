using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    // Configuration class for ExampleEntity
    public class ExampleConfigurations : IEntityTypeConfiguration<ExampleEntity>
    {
        // Method to configure the entity
        public void Configure(EntityTypeBuilder<ExampleEntity> builder)
        {
            // Configuring properties of the entity

            // Configuring FirstName property to be required
            builder.Property(obj => obj.FirstName).IsRequired();

            // Configuring LastName property to be required
            builder.Property(obj => obj.LastName).IsRequired();


            // Handling relations between DB entities

            // Example: Configuring a one-to-many relation between the current entity (ExampleEntity) and the Regions entity

            //     builder.HasMany(obj => obj.Regions) // Configuring ExampleEntity to have many Regions
            //    .WithOne() // WithOne indicates that the other end of the relationship doesn't have a navigation property
            //    .HasForeignKey(foreignKey => foreignKey.RegionId) // Configuring foreign key property
            //    .OnDelete(DeleteBehavior.Cascade); // Configuring deletion behavior
        }
    }
}
