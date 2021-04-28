using System;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class ParcelDTO.
    /// A data transfer object mapping out a Parcel to show.
    /// </summary>
    public class ParcelDTO
    {
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public string Category { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}
