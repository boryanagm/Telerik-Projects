using BeerShop.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerShop.Data.Configurations
{
	internal class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> entity)
		{
			entity.HasOne(user => user.Role)
			   .WithMany(role => role.Users)
			   .HasForeignKey(user => user.RoleId);
		}
	}
}
