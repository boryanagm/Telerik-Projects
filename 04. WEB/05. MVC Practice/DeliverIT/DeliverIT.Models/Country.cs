using Deliverit.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deliverit.Models
{
    /// <summary>
    /// Class Country.
    /// Configures the properties of a country.
    /// </summary>
    public class Country : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [StringLength(55, MinimumLength = 4, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the cities.
        /// </summary>
        /// <value>The cities.</value>
        public ICollection<City> Cities { get; set; } 
    }
}
