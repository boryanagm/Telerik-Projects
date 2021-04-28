using Deliverit.Services.Models;
using DeliverIT.Models;
using System;
using System.Linq.Expressions;

namespace Deliverit.Services.Mappers
{
    /// <summary>
    /// Class CustomerMapper.
    /// Helps map out a CustomerDTO.
    /// </summary>
    public static class CustomerMapper
    {
        public static Expression<Func<Customer, CustomerDTO>> DTOSelector = c =>
            new CustomerDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                StreetName = c.Address.StreetName,
                City = c.Address.City.Name,
                Country = c.Address.City.Country.Name
            };
    }
}
