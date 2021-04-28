using Deliverit.Services.Models;
using DeliverIT.Models;
using System;
using System.Linq.Expressions;

namespace Deliverit.Services.Mappers
{
    /// <summary>
    /// Class WarehouseMapper.
    /// Helps map out a WarehouseDTO.
    /// </summary>
    public static class WarehouseMapper
    {
        public static Expression<Func<Warehouse, WarehouseDTO>> DTOSelector = w =>
            new WarehouseDTO
            {
                Id = w.Id,
                StreetName = w.Address.StreetName,
                City = w.Address.City.Name,
                Country = w.Address.City.Country.Name
            };
    }
}
