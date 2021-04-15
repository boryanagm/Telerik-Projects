using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beers.Data.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }

		[Required, MinLength(3), MaxLength(50)]
		public string Name { get; set; }

		public List<UserRole> Roles { get; set; }

		public List<Rating> Ratings { get; set; } = new List<Rating>();
	}
}
