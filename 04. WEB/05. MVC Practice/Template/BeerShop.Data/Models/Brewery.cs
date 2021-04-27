using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerShop.Data.Models
{
	public class Brewery
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Beer> Beers { get; set; } = new List<Beer>();
    }
}
