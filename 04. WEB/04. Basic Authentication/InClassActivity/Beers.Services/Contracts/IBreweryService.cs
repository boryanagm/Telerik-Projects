using System.Collections.Generic;

using Beers.Data.Models;

namespace Beers.Services.Contracts
{
	public interface IBreweryService
	{
		List<Brewery> GetAll();
		void Delete(int id);
	}
}
