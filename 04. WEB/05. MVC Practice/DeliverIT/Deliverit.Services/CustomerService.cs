using Deliverit.Services.Contracts;
using Deliverit.Services.Models;
using DeliverIT.Database;
using DeliverIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Deliverit.Models.Authentication;
using Deliverit.Services.Mappers;

namespace Deliverit.Services
{
    /// <summary>
    /// Class CustomerService.
    /// Implements the <see cref="Deliverit.Services.Contracts.ICustomerService" />
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly DeliveritDbContext context;

        public CustomerService(DeliveritDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets a customer by email.
        /// </summary>
        /// <param name="customerEmail">The customer email.</param>
        /// <returns>The customer connected to this email.</returns>
        public Customer GetByCustomerEmail(string customerEmail)
        {
            return this.context.Customers
                 .FirstOrDefault(c => c.Email == customerEmail)
                 ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Gets a customer by Id.
        /// </summary>
        /// <param name="Id">The customer email.</param>
        /// <returns>The customer connected to this Id.</returns>
        public CustomerDTO Get(Guid id)
        {
            var dto = this.context.Customers
               .Select(CustomerMapper.DTOSelector)
               .FirstOrDefault(c => c.Id == id)
               ?? throw new ArgumentNullException();

            return dto;
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>A collection of all Customer in a CustomerDTO format</returns>
        public IEnumerable<CustomerDTO> GetAll()
        {
            List<CustomerDTO> customers = new List<CustomerDTO>();

            foreach (var customer in this.context.Customers
                .Include(c => c.Address)
                   .ThenInclude(a => a.City)
                      .ThenInclude(c => c.Country))
            {
                var dto = CustomerMapper.DTOSelector.Compile().Invoke(customer);
                customers.Add(dto);
            }
            return customers;
        }

        /// <summary>
        /// Gets the count of all customers.
        /// </summary>
        /// <returns>Returns the count of all customers.</returns>
        public int GetCount()
        {
            return this.context.Customers.Count();
        }

        /// <summary>
        /// Creates a specified customer.
        /// </summary>
        /// <param name="customer">The customer to be created.</param>
        /// <returns>A the customer that is to be created in a CustomerDTO format.</returns>
        public CustomerDTO Create(Customer customer)
        {
            this.context.Customers.Add(customer);
            customer.CreatedOn = DateTime.UtcNow;

            var customerRole = new CustomerRole()
            {
                Id = Guid.NewGuid(),
                RoleId = Guid.Parse("2d598edd-793a-4324-ac29-c505a5c790a5"),
                CustomerId = customer.Id
            };

            this.context.SaveChanges();

            var dto = this.context.Customers
               .Select(CustomerMapper.DTOSelector)
               .FirstOrDefault(c => c.Id == customer.Id);

            return dto;
        }

        /// <summary>
        /// Updates the specified Customer.
        /// </summary>
        /// <param name="id">The identifier of the customer that is to be updated..</param>
        /// <param name="addressId">The new address.</param>
        /// <returns>The updated customer in a CustomerDTO format.</returns>
        public CustomerDTO Update(Guid id, Guid addressId)
        {
            var customerToUpdate = this.context.Customers
                .FirstOrDefault(c => c.Id == id)
                ?? throw new ArgumentNullException();

            customerToUpdate.ModifiedOn = DateTime.UtcNow;
            customerToUpdate.AddressId = addressId;
            this.context.SaveChanges();

            customerToUpdate.Address = this.context.Addresses
               .Include(a => a.City)
                  .ThenInclude(c => c.Country)
               .FirstOrDefault(a => a.Id == addressId);

            var dto = CustomerMapper.DTOSelector.Compile().Invoke(customerToUpdate);

            return dto;
        }

        /// <summary>
        /// Deletes a specified customer.
        /// </summary>
        /// <param name="id">The identifier of the customer that is to be deleted.</param>
        public bool Delete(Guid id)
        {
            var customer = this.context.Customers
                 .FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                customer.DeletedOn = DateTime.UtcNow;
                customer.IsDeleted = true;
                this.context.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets customers by multiple criteria.
        /// </summary>
        /// <param name="customerFilter">The filtration.</param>
        /// <returns>A list of all customer matching the filter.</returns>
        public List<CustomerDTO> GetByMultipleCriteria(CustomerFilter customerFilter)
        {
            var searchResult = this.context.Customers
                .Where(c => c.FirstName == customerFilter.FirstName
                || c.LastName == customerFilter.LastName
                || c.Email.Contains(customerFilter.Email))
                .Select(CustomerMapper.DTOSelector)
                .ToList();

            return searchResult;
        }

        /// <summary>
        /// Gets the incoming parcels of a given customer.
        /// </summary>
        /// <param name="id">The identifier of the customer that is to be searched for.</param>
        /// <returns>List of all parcels matching the customer.</returns>
        public List<ParcelDTO> GetIncomingParcels(Guid id)
        {
            List<ParcelDTO> dto = GetIncomingParcelsMapper.ReturnIncomingParcels(context, id)
                .Select(ParcelMapper.DTOSelector)
                .ToList();

            return dto;
        }

        /// <summary>
        /// Gets the past parcels of a customer.
        /// </summary>
        /// <param name="id">The identifier of the customer that is to be searched for.</param>
        /// <returns>A list of all past parcels matching the customer.</returns>
        public List<ParcelDTO> GetPastParcels(Guid id)
        {
            List<ParcelDTO> dto = GetPastParcelsMapper.ReturnPastParcels(context, id)
                 .Select(ParcelMapper.DTOSelector)
                .ToList();

            return dto;
        }

        /// <summary>
        /// Gets a customer by a key word.
        /// </summary>
        /// <param name="key">The key word.</param>
        /// <returns>The customer matching the key word.</returns>
        public CustomerDTO GetByKeyWord(string key)
        {
            var customer = this.context.Customers
                .Include(c => c.Address)
                  .ThenInclude(a => a.City)
                    .ThenInclude(c => c.Country)
                .FirstOrDefault(c => c.FirstName == key
                || c.LastName == key
                || c.Email == key);

            var dto = CustomerMapper.DTOSelector.Compile().Invoke(customer);

            return dto;
        }
    }
}