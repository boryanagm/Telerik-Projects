using System;
using System.ComponentModel.DataAnnotations;

namespace Beers.Data.Models
{
	public class Rating
	{
		public int BeerId { get; set; }
		public Beer Beer { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		[Required]
		[Range(1, 5)]
		public int Value { get; set; }
	}
}
