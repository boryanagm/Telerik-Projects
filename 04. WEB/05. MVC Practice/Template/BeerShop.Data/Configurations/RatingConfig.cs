using BeerShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerShop.Data.Configurations
{
    internal class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> entity)
        {
            entity.HasKey(rating => new { rating.BeerId, rating.UserId });

            entity.HasOne(rating => rating.User)
                .WithMany(user => user.Ratings)
                .HasForeignKey(rating => rating.UserId);

            entity.HasOne(rating => rating.Beer)
                 .WithMany(beer => beer.Ratings)
                 .HasForeignKey(rating => rating.BeerId);
        }
    }
}
