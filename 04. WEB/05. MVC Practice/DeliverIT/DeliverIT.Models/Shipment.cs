using Deliverit.Models;
using Deliverit.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliverIT.Models
{
    /// <summary>
    /// Class Shipment.
    /// Configures the properties of a shipment.
    /// </summary>
    public class Shipment : Entity
    {
        /// <summary>
        /// Gets or sets the departure date.
        /// </summary>
        /// <value>The departure date.</value>
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Gets or sets the arrival date.
        /// </summary>
        /// <value>The arrival date.</value>
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Gets or sets the status identifier, a foreign key.
        /// </summary>
        /// <value>The status identifier.</value>
        [ForeignKey("Status")]
        public Guid StatusId { get; set; }
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the warehouse identifier.
        /// </summary>
        /// <value>The warehouse identifier.</value>
        [ForeignKey("Warehouse")]
        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        /// <summary>
        /// Gets or sets the parcels.
        /// </summary>
        /// <value>The parcels.</value>
        public ICollection<Parcel> Parcels { get; set; }
    }
}
