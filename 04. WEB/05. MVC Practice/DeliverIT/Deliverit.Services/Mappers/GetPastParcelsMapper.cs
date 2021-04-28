using DeliverIT.Database;
using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Deliverit.Services.Mappers
{
    public static class GetPastParcelsMapper
    {
        public static IQueryable<Parcel> ReturnPastParcels(DeliveritDbContext context, Guid id)
        {
            var dto = context.Customers
                   .Include(c => c.Parcels)
                      .ThenInclude(p => p.Shipment)
                        .ThenInclude(s => s.Status)
                   .Include(c => c.Parcels)
                        .ThenInclude(c => c.Category)
                   .FirstOrDefault(c => c.Id == id).Parcels
                   .Where(p => p.Shipment.Status.Name == "completed" || p.Shipment.Status.Name == "canceled").AsQueryable();

            return dto;
        }
    }
}
