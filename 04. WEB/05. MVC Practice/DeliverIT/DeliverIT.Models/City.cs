using Deliverit.Models.Abstract;
using DeliverIT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deliverit.Models
{
    /// <summary>
    /// Class City.
    /// Configures the properties of a city.
    /// </summary>
    public class City : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [StringLength(55, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country identifier, a foreign key.
        /// </summary>
        /// <value>The country identifier.</value>
        [ForeignKey("Country")]
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>The addresses.</value>
        public ICollection<Address> Addresses { get; set; }
    }
}
