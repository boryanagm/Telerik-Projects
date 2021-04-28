using Deliverit.Models.Abstract;
using DeliverIT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deliverit.Models
{    /// <summary>
     /// Class Category.
     /// Configures the properties of an category.
     /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [StringLength(35, MinimumLength = 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parcels.
        /// </summary>
        /// <value>The parcels.</value>
        public ICollection<Parcel> Parcels { get; set; }
    }
}
