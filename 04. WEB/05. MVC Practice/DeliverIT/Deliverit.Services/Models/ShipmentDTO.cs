using Deliverit.Models;
using System;
using System.Text.Json.Serialization;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class ShipmentDTO.
    /// A data transfer object mapping out a Shipment to show.
    /// </summary>
    public class ShipmentDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Status { get; set; }
        [JsonIgnore]
        public DateTime DepartureDate { get; set; }
        [JsonIgnore]
        public DateTime ArrivalDate { get; set; }      
    }
}
