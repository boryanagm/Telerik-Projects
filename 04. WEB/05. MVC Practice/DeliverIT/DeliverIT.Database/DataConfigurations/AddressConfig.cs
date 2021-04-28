using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Deliverit.Database.DataConfigurations
{
    /// <summary>
    /// Class AddressConfig.
    /// Configures the relations of the Address model. />
    /// An address has a one to many relation with Customer and Warehouse.
    /// </summary>
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasMany(a => a.Customers)
                   .WithOne(c => c.Address)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.Warehouses)
                   .WithOne(w => w.Address)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}