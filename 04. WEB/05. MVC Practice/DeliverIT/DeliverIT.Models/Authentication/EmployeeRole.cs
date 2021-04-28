using DeliverIT.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Deliverit.Models.Authentication
{
    public class EmployeeRole
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
