using Deliverit.Models;
using Deliverit.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliverIT.Models
{
    /// <summary>
    /// Class Address.
    /// Configures the properties of an address.
    /// </summary>
    public class Address : Entity
    {
        /// <summary>
        /// Gets or sets the name of the street.
        /// </summary>
        /// <value>The name of the street.</value>
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the city identifier, a foreign key.
        /// </summary>
        /// <value>The city identifier.</value>
        [ForeignKey("City")]
        public Guid CityId { get; set; }
        public City City { get; set; }


        /// <summary>
        /// Gets or sets the warehouses.
        /// </summary>
        /// <value>The warehouses.</value>
        public ICollection<Warehouse> Warehouses { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public ICollection<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>The employees.</value>
        public ICollection<Employee> Employees { get; set; }
    }
}
