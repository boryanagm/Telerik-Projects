using Deliverit.Models.Abstract;
using Deliverit.Models.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliverIT.Models
{
    /// <summary>
    /// Class Customer.
    /// Configures the properties of a customer.
    /// </summary>
    public class Customer : Entity
    { 
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public string FirstName { get; set; }


        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public string LastName { get; set; }


        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        [Required]
        public string Email { get; set; }


        /// <summary>
        /// Gets or sets the address identifier, a foreign key.
        /// </summary>
        /// <value>The address identifier.</value>
        [ForeignKey("Address")]
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the parcels.
        /// </summary>
        /// <value>The parcels.</value>
        public ICollection<Parcel> Parcels { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public ICollection<CustomerRole> Roles { get; set; }
    }
}
