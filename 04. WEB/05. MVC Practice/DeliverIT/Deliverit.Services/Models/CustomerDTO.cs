using System;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class CustomerDTO.
    /// A data transfer object mapping out a Customer to show.
    /// </summary>
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
