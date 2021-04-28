using System;
using System.Collections.Generic;
using System.Text;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class EmployeeDTO.
    /// A data transfer object mapping out a Employee to show.
    /// </summary>
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Guid> Parcels { get; set; }
    }
}
