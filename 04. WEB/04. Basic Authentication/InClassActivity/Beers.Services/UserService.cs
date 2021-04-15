using Beers.Data;
using Beers.Data.Models;
using Beers.Services.Contracts;
using Beers.Services.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Beers.Services
{
	public class UserService : IUserService
	{
		private readonly BeerDbContext dbContext;
		public UserService(BeerDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public UserDTO Get(string name)
		{
			User user = this.dbContext
								.Users
								.Include(u => u.Ratings)
									.ThenInclude(r => r.Beer)
										.ThenInclude(b => b.Brewery)
								.FirstOrDefault(u => u.Name.ToLower().Contains(name));

			UserDTO dto = new UserDTO(user);

			return dto;
		}

		public User GetByUsername(string username) => this.dbContext.Users
			.FirstOrDefault(x => x.Name == username) 
			?? throw new ArgumentNullException();
	}
}
