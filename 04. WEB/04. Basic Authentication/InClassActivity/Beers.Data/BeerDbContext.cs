using System.Collections.Generic;

using Beers.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Beers.Data
{
	public class BeerDbContext : DbContext
	{
		public BeerDbContext(DbContextOptions<BeerDbContext> options)
			   : base(options)
		{
		}

		public DbSet<Beer> Beers { get; set; }
		public DbSet<Brewery> Breweries { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Rating> Ratings { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// Configure 1-to-many between Beer and Brewery
			builder.Entity<Beer>()
				.HasOne(b => b.Brewery)
				.WithMany(br => br.Beers)
				.HasForeignKey(b => b.BreweryId);

			builder.Entity<Beer>().HasOne(beer => beer.Brewery)
				.WithMany(brewery => brewery.Beers)
				.OnDelete(DeleteBehavior.Cascade);

			// Seed Beer & Brewery
			var brewery = new Brewery()
			{
				BreweryId = 1,
				Name = "Carlsberg"
			};
			builder.Entity<Brewery>().HasData(brewery);
			
			var beers = new List<Beer>()
			{
				new Beer()
				{
					BeerId = 1,
					Name = "Pirinsko",
					BreweryId = 1
				},
				new Beer()
				{
					BeerId = 2,
					Name = "Shumensko",
					BreweryId = 1
				},
			};
			builder.Entity<Beer>().HasData(beers);

			// Configure many-to-many between Beer and User using Rating
			builder
				.Entity<Rating>()
				.HasKey(r => new { r.BeerId, r.UserId });

			builder.Entity<Rating>()
				.HasOne(r => r.Beer)
				.WithMany(b => b.Ratings)
				.HasForeignKey(r => r.BeerId);

			builder.Entity<Rating>()
				.HasOne(r => r.User)
				.WithMany(u => u.Ratings)
				.HasForeignKey(r => r.UserId);

			// Seed User & Rating
			var users = new List<User>()
			{
				new User() { UserId = 1, Name = "Gosho" },
				new User() { UserId = 2, Name = "Pesho" }
			};
			builder.Entity<User>().HasData(users);
			
			var ratings = new List<Rating>()
			{
				new Rating() {BeerId = 1, UserId = 1, Value = 5 },
				new Rating() {BeerId = 2, UserId = 1, Value = 3 },
				new Rating() {BeerId = 1, UserId = 2, Value = 1 },
				new Rating() {BeerId = 2, UserId = 2, Value = 1 },
			};
			builder.Entity<Rating>().HasData(ratings);

			base.OnModelCreating(builder);
		}
	}
}
