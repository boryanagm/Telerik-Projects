using BeerShop.Data;
using BeerShop.Data.Models;
using BeerShop.Services.Contracts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace BeerShop.Services
{
	public class UserService : IUserService
	{
		private readonly BeerShopContext context;

		public UserService(BeerShopContext context)
		{
			this.context = context;
		}

		public User Get(string email)
		{
			var user = this.context.Users
							.Include(user => user.Role)
							.Include(user => user.Ratings)
								.ThenInclude(rating => rating.Beer)
									.ThenInclude(beer => beer.Brewery)
							.FirstOrDefault(user => user.Email.Contains(email));
			return user;
		}

		public List<User> GetAll()
		{
			var users = this.context.Users
							.Include(user => user.Role)
							.Include(user => user.Ratings)
								.ThenInclude(rating => rating.Beer)
									.ThenInclude(beer => beer.Brewery)
							.ToList();
			return users;
		}
	}
}
