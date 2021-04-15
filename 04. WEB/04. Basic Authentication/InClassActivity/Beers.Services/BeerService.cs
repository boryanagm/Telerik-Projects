using System;
using System.Collections.Generic;
using System.Linq;

using Beers.Data;
using Beers.Data.Models;
using Beers.Services.Contracts;
using Beers.Services.Models;

using Microsoft.EntityFrameworkCore;

namespace Beers.Services
{
	public class BeerService : IBeerService
	{
		private readonly BeerDbContext dbContext;

		public BeerService(BeerDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public BeerDTO Get(int id)
		{
			// Data model
			Beer beer = this.dbContext
							.Beers
							.Include(b => b.Brewery)
							.Include(b => b.Ratings)
								.ThenInclude(r => r.User)
							.FirstOrDefault(b => b.BeerId == id);

			// Service model
			BeerDTO beerDTO = new BeerDTO();
			beerDTO.Name = beer.Name;
			beerDTO.Brewery = beer.Brewery.Name;
			foreach (var rating in beer.Ratings)
			{
				var pair = new Tuple<string, double>(rating.User.Name, rating.Value);
				beerDTO.UserRatings.Add(pair);
			}

			return beerDTO;
		}

		public List<Beer> GetAll()
		{
			var beers = this.dbContext.Beers.Include(b => b.Brewery).ToList();

			return beers;
		}
		public Beer Create(int id, Beer beer)
		{
			var user = this.dbContext.Users
				.FirstOrDefault(u => u.UserId == id)
				?? throw new ArgumentNullException();

			this.dbContext.Beers.Add(beer);
			beer.UserId = user.UserId;
			this.dbContext.SaveChanges();

			return beer;
		}

		public Beer Update(int id, string name)
		{
			var beer = this.dbContext.Beers
					.FirstOrDefault(beer => beer.BeerId == id)
					?? throw new ArgumentNullException();

			beer.Name = name;
			this.dbContext.SaveChanges();

			return beer;
		}

		public void Delete(int id)
		{
			var beer = this.dbContext.Beers
				.FirstOrDefault(beer => beer.BeerId == id)
				?? throw new ArgumentNullException();

			this.dbContext.Beers.Remove(beer);
			this.dbContext.SaveChanges();
		}
	}
}
