using System;

namespace Deliverit.Services.Models
{
    /// <summary>
    /// Class CountryDTO.
    /// A data transfer object mapping out a Country to show.
    /// </summary>
    public class CountryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfCities { get; set; }      
    }
}
