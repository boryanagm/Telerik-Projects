using BeerShop.Data.Models;
using BeerShop.Services.Contracts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerShop.Services
{
	public class BeerService : IBeerService
	{
		private readonly BeerShop.Data.BeerShopContext context;
		public BeerService(BeerShop.Data.BeerShopContext context)
		{
			this.context = context;
		}
		public Beer Get(int id)
		{
			var beer = this.context.Beers
				.Include(x => x.Brewery)
				.Include(x => x.Ratings)
				  .ThenInclude(x => x.User)
					.ThenInclude(user => user.Role)
				.FirstOrDefault(x => x.Id == id)
				?? throw new ArgumentNullException();

			return beer;
		}

		public IEnumerable<Beer> GetAll()
		{
			var beers = this.context.Beers;

			return beers;
		}

		public Beer Create(Beer beer)
		{
			this.context.Beers.Add(beer);
			this.context.SaveChanges();

			return beer;
		}

		public Beer Update(int id, string name)
		{
			var beer = this.context.Beers
				.FirstOrDefault(x => x.Id == id)
				?? throw new ArgumentNullException();

			beer.Name = name;
			this.context.SaveChanges();

			return beer;
		}

		public bool Delete(int id)
		{
			var beer = this.context.Beers
				.FirstOrDefault(beer => beer.Id == id);

			if (beer == null)
			{
				return false;
			}

			var outcome = this.context.Beers.Remove(beer);
			this.context.SaveChanges();
			return true;
		}
	}
}
