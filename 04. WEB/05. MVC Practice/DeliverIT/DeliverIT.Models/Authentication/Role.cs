using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Deliverit.Models.Authentication
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<CustomerRole> CustomerRoles { get; set; }
        public ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
