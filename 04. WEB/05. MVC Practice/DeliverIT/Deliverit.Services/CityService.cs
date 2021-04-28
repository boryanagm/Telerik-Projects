using Deliverit.Services.Contracts;
using Deliverit.Services.Models;
using DeliverIT.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deliverit.Services
{
    /// <summary>
    /// Class CityService.
    /// Implements the <see cref="Deliverit.Services.Contracts.ICityService" />
    /// Responsible for read operations.
    /// </summary>
    public class CityService : ICityService
    {
        private readonly DeliveritDbContext context;

        public CityService(DeliveritDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The Id of city to be displayed</param>
        /// <returns>a City in a CityDTO format.</returns>
        public CityDTO Get(Guid id)
        {
            var city = this.context.Cities
                .FirstOrDefault(c => c.Id == id)
                ?? throw new ArgumentNullException();

            CityDTO dto = new CityDTO();

            dto.Id = city.Id;
            dto.Name = city.Name;

            return dto;
        }

        /// <summary>
        /// Gets all cities.
        /// </summary>
        /// <returns>A collection of all cities.</returns>
        public IEnumerable<CityDTO> GetAll()
        {
            List<CityDTO> cities = new List<CityDTO>();

            foreach (var city in this.context.Cities)
            {
                CityDTO cityToAdd = new CityDTO
                {
                    Id = city.Id,
                    Name = city.Name
                };

                cities.Add(cityToAdd);
            }

            return cities;
        }
    }
}
