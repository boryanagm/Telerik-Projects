using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreOverview.Models
{
	public class Beer
    {
        public int Id { get; set; }
       
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string Name { get; set; }

        [Range(0.1, 35.00, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Abv { get; set; }
    }
}
