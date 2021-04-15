using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beers.Data.Models
{
	public class Beer
	{
		[Key]
		public int BeerId { get; set; }

		[Required, MinLength(3), MaxLength(50)]
		public string Name { get; set; }

		public double ABV { get; set; }

		public int BreweryId { get; set; }
		public Brewery Brewery { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		public List<Rating> Ratings { get; set; } = new List<Rating>();
	}
}