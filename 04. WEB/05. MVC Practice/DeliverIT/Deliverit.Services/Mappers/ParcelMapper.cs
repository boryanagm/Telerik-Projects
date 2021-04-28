using Deliverit.Services.Models;
using DeliverIT.Models;
using System;
using System.Linq.Expressions;

namespace Deliverit.Services.Mappers
{
    /// <summary>
    /// Class ParcelMapper.
    /// Helps map out a ParcelDTO.
    /// </summary>
    public static class ParcelMapper
    {
        public static Expression<Func<Parcel, ParcelDTO>> DTOSelector = p =>
           new ParcelDTO
           {
               Id = p.Id,
               Weight = p.Weight,
               Category = p.Category.Name,
               CustomerFirstName = p.Customer.FirstName,
               CustomerLastName = p.Customer.LastName
           };
    }
}
