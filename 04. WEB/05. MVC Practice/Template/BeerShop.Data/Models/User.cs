using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerShop.Data.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required, MinLength(1), MaxLength(10)]
		public string Name { get; set; }

		public int RoleId { get; set; }
		public Role Role { get; set; }

		public List<Rating> Ratings { get; set; } = new List<Rating>();
	}
}
