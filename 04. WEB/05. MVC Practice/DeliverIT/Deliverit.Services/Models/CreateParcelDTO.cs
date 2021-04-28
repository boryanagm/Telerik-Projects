using Deliverit.Models;
using System;
using System.Text.Json.Serialization;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class CreateCityDTO.
    /// A data transfer object mapping out a Parcel to be created.
    /// </summary>
    public class CreateParcelDTO
    {
        public int Weight { get; set; }
        public string CategoryName { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShipmentId { get; set; }
    }
}
