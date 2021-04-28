using DeliverIT.Database;
using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Deliverit.Services.Mappers
{
    public static class GetIncomingParcelsMapper
    {
        public static IQueryable<Parcel> ReturnIncomingParcels(DeliveritDbContext context, Guid id)
        {
            var dto = context.Customers
                   .Include(c => c.Parcels)
                      .ThenInclude(p => p.Shipment)
                        .ThenInclude(s => s.Status)
                   .Include(c => c.Parcels)
                        .ThenInclude(c => c.Category)
                   .FirstOrDefault(c => c.Id == id).Parcels
                   .Where(p => p.Shipment.Status.Name == "on the way" || p.Shipment.Status.Name == "preparing").AsQueryable();

            return dto;
        }
    }
}
