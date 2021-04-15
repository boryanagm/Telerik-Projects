using System.Collections.Generic;

using Beers.Data.Models;

namespace Beers.Services.Models
{
	public class UserDTO
	{
		public UserDTO(User user)
		{
			this.Name = user.Name;

			this.Beers = new List<string>();
			foreach (Rating rating in user.Ratings)
			{
				this.Beers.Add($"{rating.Beer.Name} ({rating.Value}), {rating.Beer.Brewery.Name}");
			}
		}

		public string Name { get; }
		public List<string> Beers { get; }
	}
}
