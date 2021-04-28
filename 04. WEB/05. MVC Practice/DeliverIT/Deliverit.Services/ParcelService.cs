using Deliverit.Services.Contracts;
using Deliverit.Services.Mappers;
using Deliverit.Services.Models;
using DeliverIT.Database;
using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deliverit.Services
{
    /// <summary>
    /// Class ParcelService.
    /// Implements the <see cref="Deliverit.Services.Contracts.IParcelService" />
    /// Defines all CRUD/Filter/Search operations for a parcel.
    /// </summary>
    public class ParcelService : IParcelService
    {
        private readonly DeliveritDbContext context;

        public ParcelService(DeliveritDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the Parcel by ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Parcel in a ParcelDTO format.</returns
        public ParcelDTO Get(Guid id)
        {
            var parcel = this.context.Parcels
                .Include(p => p.Category)
                .Include(p => p.Customer)
                .FirstOrDefault(p => p.Id == id)
                ?? throw new ArgumentNullException();

            var dto = ParcelMapper.DTOSelector.Compile().Invoke(parcel);

            return dto;
        }

        /// <summary>
        /// Gets all Parcels.
        /// </summary>
        /// <returns>A collection of all parcels.</returns>
        public IEnumerable<ParcelDTO> GetAll()
        {
            List<ParcelDTO> parcels = new List<ParcelDTO>();

            foreach (var parcel in this.context.Parcels.Include(p => p.Category).Include(p => p.Customer))
            {
                var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel);
                parcels.Add(parcelToDisplay);
            }
            return parcels;
        }

        /// <summary>
        /// Creates a parcel.
        /// </summary>
        /// <param name="parcel">The parcel that is to be created.</param>
        /// <returns>The parcel in a ParcelDTO format.</returns>
        public ParcelDTO Create(CreateParcelDTO parcel)
        {
            var shipment = this.context.Shipments
                .Include(s => s.Status)
                .FirstOrDefault(s => s.Id == parcel.ShipmentId);

            var customer = this.context.Customers
                .FirstOrDefault(c => c.Id == parcel.CustomerId);
            var category = this.context.Categories
                .FirstOrDefault(c => c.Name == parcel.CategoryName);
            var employee = this.context.Employees
                .FirstOrDefault(c => c.Id == parcel.EmployeeId);
            var newParcel = new Parcel
            {
                Weight = parcel.Weight,
                Category = category,
                Employee = employee,
                Customer = customer,
                Shipment = shipment,
                CreatedOn = DateTime.UtcNow
            };
            this.context.Parcels.Add(newParcel);
            this.context.SaveChanges();

            var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(newParcel); ;

            return parcelToDisplay;
        }

        /// <summary>
        /// Updates the specified parcel.
        /// </summary>
        /// <param name="id">The identifier of the parcel.</param>
        /// <param name="parcel">The update data.</param>
        /// <returns>ParcelDTO.</returns>
        public ParcelDTO Update(Guid id, UpdateParcelDTO parcel)
        {
            var parcelToUpdate = this.context.Parcels
                .Include(p => p.Category)
                .Include(p => p.Customer)
                .FirstOrDefault(s => s.Id == id)
                ?? throw new ArgumentNullException();

            if (parcel.CustomerId != new Guid("{00000000-0000-0000-0000-000000000000}"))
            {
                var customer = this.context.Customers
                .FirstOrDefault(s => s.Id == parcel.CustomerId)
                ?? throw new ArgumentNullException();
                parcelToUpdate.Customer = customer;
            }

            if (parcel.CategoryId != new Guid("{00000000-0000-0000-0000-000000000000}"))
            {
                var category = this.context.Categories
                .FirstOrDefault(s => s.Id == parcel.CategoryId)
                ?? throw new ArgumentNullException();
                parcelToUpdate.Category = category;
            }

            if (parcel.ShipmentId != new Guid("{00000000-0000-0000-0000-000000000000}"))
            {
                var shipment = this.context.Shipments
                .FirstOrDefault(s => s.Id == parcel.ShipmentId)
                ?? throw new ArgumentNullException();
                parcelToUpdate.Shipment = shipment;
            }

            if (parcel.Weight > 0)
                parcelToUpdate.Weight = parcel.Weight;

            var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcelToUpdate); ;

            return parcelToDisplay;
        }

        /// <summary>
        /// Deletes the specified parcel.
        /// </summary>
        /// <param name="id">The identifier of the parcel.</param>
        public bool Delete(Guid id)
        {
            var parcel = this.context.Parcels
                .FirstOrDefault(s => s.Id == id)
                ?? throw new ArgumentNullException();

            parcel.IsDeleted = true;
            parcel.DeletedOn = DateTime.UtcNow;
            this.context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Searches all parcels by e-mail.
        /// </summary>
        /// <param name="email">The email that is to be searched for.</param>
        /// <returns>A collection of all parcels that are connected to this e-mail.</returns>
        public List<ParcelDTO> SearchByEmail(string email)
        {
            var customers = this.context.Customers
                .Include(c => c.Parcels)
                .ThenInclude(c => c.Category)
                .Where(s => s.Email.Contains(email))
                .ToList();

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var customer in customers)
            {
                foreach (var parcel in customer.Parcels)
                {
                    var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel);
                    parcelsToDisplay.Add(parcelToDisplay);
                }
            }
            return parcelsToDisplay;
        }

        /// <summary>
        /// Searches all parcel by the name of the customer.
        /// </summary>
        /// <param name="firstname">The firstname of the customer.</param>
        /// <param name="lastname">The lastname of the customer.</param>
        /// <returns>A collection of all parcel connected to those names.</returns>
        public List<ParcelDTO> SearchByName(string firstname, string lastname)
        {
            List<Customer> customers = new List<Customer>();

            if (firstname != null && lastname == null)
            {
                customers = this.context.Customers
                   .Include(c => c.Parcels)
                   .ThenInclude(c => c.Category)
                   .Where(s => s.FirstName == firstname)
                   .ToList();
            }

            else if (firstname == null && lastname != null)
            {
                customers = this.context.Customers
                   .Include(c => c.Parcels)
                   .ThenInclude(c => c.Category)
                   .Where(s => s.LastName == lastname)
                   .ToList();
            }

            else
            {
                customers = this.context.Customers
                  .Include(c => c.Parcels)
                  .ThenInclude(c => c.Category)
                  .Where(s => s.LastName == lastname && s.FirstName == firstname)
                  .ToList();
            }

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var customer in customers)
            {
                foreach (var parcel in customer.Parcels)
                {
                    var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel); ;
                    parcelsToDisplay.Add(parcelToDisplay);
                }
            }
            return parcelsToDisplay;
        }

        /// <summary>
        /// Finds the incoming parcels of a customer.
        /// </summary>
        /// <param name="Id">The identifier of the customer.</param>
        /// <returns>A collection of all incoming parcels to the given customer.</returns>
        public List<ParcelDTO> FindIncomingParcels(Guid Id)
        {
            var customer = this.context.Customers
               .Include(c => c.Parcels)
               .ThenInclude(c => c.Shipment)
               .ThenInclude(c => c.Status)
               .Include(c => c.Parcels)
               .ThenInclude(c => c.Category)
               .FirstOrDefault(s => s.Id == Id)
               ?? throw new ArgumentNullException();

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var parcel in customer.Parcels)
            {
                if (parcel.Shipment.Status.Name == "on the way")
                {
                    var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel);
                    parcelsToDisplay.Add(parcelToDisplay);
                }
            }

            return parcelsToDisplay;
        }

        /// <summary>
        /// Gets all parcels of a given warehouse.
        /// </summary>
        /// <param name="id">The identifier of the warehouse.</param>
        /// <returns>A collection of all parcels of the given warehouse.</returns>
        public List<ParcelDTO> GetByWarehouse(Guid id)
        {
            var parcels = this.context.Parcels
                .Include(p => p.Shipment)
                .ThenInclude(p => p.Warehouse)
                .Include(p => p.Category)
                .Include(p => p.Customer)
                .Where(p => p.Shipment.Warehouse.Id == id)
                .ToList();

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var parcel in parcels)
            {
                var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel);
                parcelsToDisplay.Add(parcelToDisplay);
            }

            return parcelsToDisplay;
        }

        /// <summary>
        /// Gets all parcels of a given customer.
        /// </summary>
        /// <param name="id">The identifier of the customer.</param>
        /// <returns>A collection of all parcels of a given customer.</returns>
        public List<ParcelDTO> GetByCustomer(Guid id)
        {
            var parcels = this.context.Parcels
                .Include(p => p.Category)
                .Include(p => p.Customer)
                .Where(p => p.Customer.Id == id)
                .ToList();

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var parcel in parcels)
            {
                var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel); ;
                parcelsToDisplay.Add(parcelToDisplay);
            }

            return parcelsToDisplay;
        }

        /// <summary>
        /// Gets all parcels by weight.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <returns>A collection of all parcels with a given weight.</returns>
        public List<ParcelDTO> GetByWeight(int weight)
        {
            var parcels = this.context.Parcels
                .Include(p => p.Category)
                .Include(p => p.Customer)
                .Where(p => p.Weight == weight)
                .ToList();

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var parcel in parcels)
            {
                var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel);
                parcelsToDisplay.Add(parcelToDisplay);
            }

            return parcelsToDisplay;
        }

        /// <summary>
        /// Gets all parcels by category.
        /// </summary>
        /// <param name="category">The category's name.</param>
        /// <returns>A collection of all parcels of a given category.</returns>
        public List<ParcelDTO> GetByCategory(string category)
        {
            var parcels = this.context.Parcels
                .Include(p => p.Category)
                .Include(p => p.Customer)
                .Where(p => p.Category.Name == category)
                .ToList();

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var parcel in parcels)
            {
                var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel);
                parcelsToDisplay.Add(parcelToDisplay);
            }

            return parcelsToDisplay;
        }
        public List<ParcelDTO> GetByMultipleCriteria(string category, Guid Id)
        {
            var parcels = this.context.Parcels
                .Include(p => p.Category)
                .Include(p => p.Customer)
                .Where(p => p.Category.Name == category && p.CustomerId == Id)
                .ToList();

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var parcel in parcels)
            {
                var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel);
                parcelsToDisplay.Add(parcelToDisplay);
            }

            return parcelsToDisplay;
        }

        public List<ParcelDTO> SortByWeightOrArrivalDate(string sortcriteria)
        {
            var parcels = this.context.Parcels
                .Include(p => p.Shipment)
                .Include(p => p.Customer)
                .Include(p=>p.Category);

            if (sortcriteria == "weight")
                parcels.OrderBy(p => p.Weight);

            if (sortcriteria == "date")
                parcels.OrderBy(p => p.Shipment.ArrivalDate);

            List<ParcelDTO> parcelsToDisplay = new List<ParcelDTO>();
            foreach (var parcel in parcels)
            {
                var parcelToDisplay = ParcelMapper.DTOSelector.Compile().Invoke(parcel);
                parcelsToDisplay.Add(parcelToDisplay);
            }

            return parcelsToDisplay;
        }
    }
}
