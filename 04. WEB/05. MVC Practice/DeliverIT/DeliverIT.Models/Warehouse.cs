using Deliverit.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliverIT.Models
{
    /// <summary>
    /// Class Warehouse.
    /// Configures the properties of a warehouse.
    /// </summary>
    public class Warehouse : Entity
    {
        /// <summary>
        /// Gets or sets the address identifier, a foreign key.
        /// </summary>
        /// <value>The address identifier.</value>
        [ForeignKey("Address")]
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the shipments.
        /// </summary>
        /// <value>The shipments.</value>
        public ICollection<Shipment> Shipments { get; set; }
    }
}
