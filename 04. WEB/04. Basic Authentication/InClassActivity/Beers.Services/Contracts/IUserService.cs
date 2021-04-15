
using Beers.Services.Models;

namespace Beers.Services.Contracts
{
	public interface IUserService
	{
		UserDTO Get(string name);
	}
}
