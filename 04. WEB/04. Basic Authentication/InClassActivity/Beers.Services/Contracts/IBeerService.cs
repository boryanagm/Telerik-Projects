using System.Collections.Generic;

using Beers.Data.Models;
using Beers.Services.Models;

namespace Beers.Services.Contracts
{
	public interface IBeerService
	{
		BeerDTO Get(int id);
		List<Beer> GetAll();
		void Delete(int id);
		Beer Update(int id, string name);
	}
}
