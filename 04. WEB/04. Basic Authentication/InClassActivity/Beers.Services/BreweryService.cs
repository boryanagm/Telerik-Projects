using System.Collections.Generic;
using System.Linq;

using Beers.Data;
using Beers.Data.Models;
using Beers.Services.Contracts;

using Microsoft.EntityFrameworkCore;

namespace Beers.Services
{
	public class BreweryService : IBreweryService
	{
		private readonly BeerDbContext dbContext;

		public BreweryService(BeerDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public List<Brewery> GetAll()
		{
			return this.dbContext.Breweries.Include(b => b.Beers).ToList();
		}

		public void Delete(int id)
		{
			var brewery = this.dbContext.Breweries.FirstOrDefault(b => b.BreweryId == id);
			this.dbContext.Breweries.Remove(brewery);
			this.dbContext.SaveChanges();
		}
	}
}
