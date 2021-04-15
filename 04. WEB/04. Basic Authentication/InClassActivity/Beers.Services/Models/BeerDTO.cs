using System;
using System.Collections.Generic;

namespace Beers.Services.Models
{
	public class BeerDTO
	{
		public string Name { get; set; }
		public string Brewery { get; set; }
		public List<Tuple<string, double>> UserRatings { get; set; } = new List<Tuple<string, double>>();
	}
}
