using Deliverit.Services.Contracts;
using Deliverit.Services.Models;
using DeliverIT.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deliverit.Services
{
    /// <summary>
    /// Class CountryService.
    /// Implements the <see cref="Deliverit.Services.Contracts.ICountryService" />
    /// </summary>
    public class CountryService : ICountryService
    {
        private readonly DeliveritDbContext context;

        public CountryService(DeliveritDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The Id of the Country to be displayed.</param>
        /// <returns>A country in a CountryDTO format.</returns>
        public CountryDTO Get(Guid id)
        {
            var country = this.context.Countries
                .Include(c=> c.Cities)
                .FirstOrDefault(c => c.Id == id)
                ?? throw new ArgumentNullException();
            var dto = new CountryDTO
            {
                Id = country.Id,
                Name = country.Name,
                NumberOfCities = country.Cities.Count(),
            };

            return dto;
        }

        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns>A collection of all countries in a CountryDTO format.</returns>
        public IEnumerable<CountryDTO> GetAll()
        {
            List<CountryDTO> countries = new List<CountryDTO>();

            foreach(var country in this.context.Countries.Include(c=>c.Cities))
            {
                CountryDTO countryToAdd = new CountryDTO
                {
                    Id = country.Id,
                    Name = country.Name,
                    NumberOfCities = country.Cities.Count()                 
                };

                countries.Add(countryToAdd);
            }

            return countries;
        }
    }
}
