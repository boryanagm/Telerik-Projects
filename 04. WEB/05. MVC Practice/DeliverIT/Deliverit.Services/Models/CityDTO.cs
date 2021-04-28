using System;
using System.Collections.Generic;
using System.Text;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class CityDTO.
    /// A data transfer object mapping out a City to show.
    /// </summary>
    public class CityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
