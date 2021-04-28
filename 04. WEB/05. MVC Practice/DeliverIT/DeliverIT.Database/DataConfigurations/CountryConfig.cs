using Deliverit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deliverit.Database.DataConfigurations
{
    /// <summary>
    /// Class CountryConfig.
    /// Configures the relations of the Country model. />
    /// </summary>
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
