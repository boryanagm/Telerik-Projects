using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Deliverit.Database.DataConfigurations
{
    /// <summary>
    /// Class EmployeeConfig.
    /// Configures the relations of the Employee model. />
    /// Each employee has a unique e-mail and a one to many relation with Parcel.
    /// </summary>
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(s => s.Parcels)
                   .WithOne(p => p.Employee)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.Email).IsUnique();

            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
    /*
     Exercise with Fluent Api:

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                   .HasMaxLength(35)
                   .IsRequired();

            builder.Property(e => e.LastName)
                   .HasMaxLength(35)
                   .IsRequired();

            builder.HasOne(e => e.Address)
                   .WithMany(a => a.Employees)
                   .HasForeignKey(e => e.AddressId);
     */
}
