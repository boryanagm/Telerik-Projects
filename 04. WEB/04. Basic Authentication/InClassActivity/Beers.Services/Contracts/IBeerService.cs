using System.Collections.Generic;

using Beers.Data.Models;
using Beers.Services.Models;

namespace Beers.Services.Contracts
{
	public interface IBeerService
	{
		BeerDTO Get(int id);
		List<Beer> GetAll();
		Beer Create(int id, Beer beer);
		void Delete(int id);
		Beer Update(int id, string name);
		Beer Rate(int beerId, int userId, int rate);
	}
}
