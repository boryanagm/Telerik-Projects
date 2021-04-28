using Deliverit.Services.Models;
using DeliverIT.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Deliverit.Services.Extension_Methods
{
    /// <summary>
    /// Class EmployeeMapper.
    /// Helps map out a EmployeeDTO.
    /// </summary>
    public static class EmployeeMapper
    {
        public static Expression<Func<Employee, EmployeeDTO>> DTOSelector = e =>
            new EmployeeDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                StreetName = e.Address.StreetName,
                City = e.Address.City.Name,
                Country = e.Address.City.Country.Name,
                Parcels = e.Parcels.Select(p => p.Id).ToList()
            };
    }
}

/*
 
        public static EmployeeDTO ToEmployeeDTO(this Employee employee) // Not working
        {
            return new EmployeeDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                StreetName = employee.Address.StreetName,
                City = employee.Address.City.Name,
                Country = employee.Address.City.Country.Name,
                Parcels = employee.Parcels.Select(p => p.Id).ToList()
            };
        }
 */
