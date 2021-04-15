using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Beers.Data.Models
{
	public class Brewery
	{
		[Key]
		public int BreweryId { get; set; }

		[Required, MinLength(3), MaxLength(50)]
		public string Name { get; set; }

		public List<Beer> Beers { get; set; } = new List<Beer>();
	}
}
