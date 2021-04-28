using Deliverit.Services.Contracts;
using DeliverIT.Database;
using DeliverIT.Models;
using System;

namespace Deliverit.Services
{
    /// <summary>
    /// Class AdressService.
    /// Implements the <see cref="Deliverit.Services.Contracts.IAddressService" />
    /// Responsible for creating an address.
    /// </summary>
    public class AdressService : IAddressService
    {
        private readonly DeliveritDbContext context;

        public AdressService(DeliveritDbContext context)
        {
            this.context = context;
        }

        public Address Create(Address address)
        {
            this.context.Addresses.Add(address);
            address.CreatedOn = DateTime.UtcNow;
            this.context.SaveChanges();

            return address;
        }
    }
}
