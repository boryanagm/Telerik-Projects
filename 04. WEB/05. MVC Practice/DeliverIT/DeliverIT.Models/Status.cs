using Deliverit.Models.Abstract;
using DeliverIT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deliverit.Models
{
    /// <summary>
    /// Class Status.
    /// Configures the properties of a status.
    /// </summary>
    public class Status : Entity
    { 
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [StringLength(35, MinimumLength = 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the shipments.
        /// </summary>
        /// <value>The shipments.</value>
        public ICollection<Shipment> Shipments { get; set; }
    }
}
