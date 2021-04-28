using DeliverIT.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Deliverit.Models.Authentication
{
    public class CustomerRole
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
