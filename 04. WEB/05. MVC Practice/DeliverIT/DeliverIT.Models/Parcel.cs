using Deliverit.Models;
using Deliverit.Models.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliverIT.Models
{
    /// <summary>
    /// Class Parcel.
    /// Configures the properties of a parcel.
    /// </summary>
    public class Parcel : Entity
    {
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        [Range(1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public int Weight { get; set; }


        /// <summary>
        /// Gets or sets the category identifier, a foreign key.
        /// </summary>
        /// <value>The category identifier.</value>
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier, a foreign key.
        /// </summary>
        /// <value>The customer identifier.</value>
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }


        /// <summary>
        /// Gets or sets the employee identifier, a foreign key.
        /// </summary>
        /// <value>The employee identifier.</value>
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }


        /// <summary>
        /// Gets or sets the shipment identifier, a foreign key.
        /// </summary>
        /// <value>The shipment identifier.</value>
        [ForeignKey("Shipment")] // TODO: Make it not required?
        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}
