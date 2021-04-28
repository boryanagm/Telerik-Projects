using System;
using System.Collections.Generic;
using System.Text;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class UpdateParcelDTO.
    /// A data transfer object mapping out a Parcel to update.
    /// </summary>
    public class UpdateParcelDTO
    {
        public int Weight { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ShipmentId { get; set; }
    }
}
