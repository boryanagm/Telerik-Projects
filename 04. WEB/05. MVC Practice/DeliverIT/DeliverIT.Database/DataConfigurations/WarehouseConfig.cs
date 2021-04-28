using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Deliverit.Database.DataConfigurations
{
    /// <summary>
    /// Class WarehouseConfig.
    /// Configures the relations of Warehouse. />
    /// A warehouse has many shipments and it's address has many warehouses.
    /// </summary>
    public class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {

            builder.HasMany(s => s.Shipments)
                .WithOne(w => w.Warehouse)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(w => w.Address)
                   .WithMany(a => a.Warehouses)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(w => !w.IsDeleted);
        }
    }
    /*
     Exercise with Fluent Api:

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Category)

            builder.HasOne(w => w.Address)
                   .WithOne(a => a.Warehouse)
                   .HasForeignKey<Address>(w => w.Warehouse);
     */
}
