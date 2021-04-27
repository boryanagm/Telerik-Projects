using System.Collections.Generic;

using BeerShop.Data.Configurations;
using BeerShop.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace BeerShop.Data
{
	public class BeerShopContext : DbContext
	{
		public BeerShopContext(DbContextOptions<BeerShopContext> options)
			: base(options) { }

		public BeerShopContext() { }

		public DbSet<Beer> Beers { get; set; }
		public DbSet<Brewery> Breweries { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Rating> Ratings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BeerConfig());
			modelBuilder.ApplyConfiguration(new UserConfig());
			modelBuilder.ApplyConfiguration(new RatingConfig());

			this.Seed(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		protected virtual void Seed(ModelBuilder modelBuilder)
		{
			var roles = new List<Role>
			{
				new Role { Id = 1, Name = "admin" },
				new Role { Id = 2, Name = "user" }
			};

			var users = new List<User>
			{
				new User
				{
					Id = 1,
					Email = "alice@beershop.com",
					Name = "Alice",
					RoleId = 1
				},
				new User
				{
					Id = 2,
					Email = "bob@beershop.com",
					Name = "Bob",
					RoleId = 2
				}
			};

			var breweries = new List<Brewery>()
			{
				new Brewery()
				{
					Id = 1,
					Name = "The Underground"
				},
				new Brewery()
				{
					Id = 2,
					Name = "Beerarium"
				},
			};

			var beers = new List<Beer>
			{
				new Beer
				{
					Id = 1,
					Name = "London Pride",
					Abv = 5.0,
					BreweryId = 1
				},
				new Beer
				{
					Id = 2,
					Name = "Cheers",
					Abv = 4.5,
					BreweryId = 1
				},
				new Beer
				{
					Id = 3,
					Name = "Honey Dew",
					Abv = 4.8,
					BreweryId = 2
				}
			};

			var ratings = new List<Rating>
			{
				new Rating
				{
					UserId = 1,
					BeerId = 1,
					Value = 3
				},
				new Rating
				{
					UserId = 1,
					BeerId = 2,
					Value = 1
				},
				new Rating
				{
					UserId = 1,
					BeerId = 3,
					Value = 4
				},
				new Rating
				{
					UserId = 2,
					BeerId = 1,
					Value = 5
				},
				new Rating
				{
					UserId = 2,
					BeerId = 2,
					Value = 2
				},
				new Rating
				{
					UserId = 2,
					BeerId = 3,
					Value = 3
				}
			};

			modelBuilder.Entity<Role>().HasData(roles);
			modelBuilder.Entity<User>().HasData(users);
			modelBuilder.Entity<Beer>().HasData(beers);
			modelBuilder.Entity<Brewery>().HasData(breweries);
			modelBuilder.Entity<Rating>().HasData(ratings);
		}
	}
}
