using BeerShop.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerShop.Data.Configurations
{
	internal class BeerConfig : IEntityTypeConfiguration<Beer>
	{
		public void Configure(EntityTypeBuilder<Beer> entity)
		{
			entity.HasOne(beer => beer.Brewery)
			   .WithMany(brewery => brewery.Beers)
			   .HasForeignKey(beer => beer.BreweryId);
		}
	}
}
