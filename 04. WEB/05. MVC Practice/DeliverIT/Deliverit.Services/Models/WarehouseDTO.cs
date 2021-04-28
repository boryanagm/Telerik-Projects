using System;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class WarehouseDTO.
    /// A data transfer object mapping out a Warehouse to show.
    /// </summary>
    public class WarehouseDTO
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
