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
    /// Class ShipmentService.
    /// Defines all CRUD/Search operations.
    /// Implements the <see cref="Deliverit.Services.Contracts.IShipmentService" />
    /// </summary>
    public class ShipmentService : IShipmentService
    {
        private readonly DeliveritDbContext context;

        public ShipmentService(DeliveritDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets a customer by Id.
        /// </summary>
        /// <param name="id">The identifier of the customer.</param>
        /// <returns>The customer in a CustomerDTO format.</returns>
        public ShipmentDTO Get(Guid id)
        {
            var shipment = this.context.Shipments
                .Include(c => c.Status)
                .FirstOrDefault(s => s.Id == id)
                ?? throw new ArgumentNullException();

            if (shipment.IsDeleted == true)
                throw new ArgumentException("A shipment with this ID doesn't exist.");

            var dto = ShipmentMapper.DTOSelector.Compile().Invoke(shipment);

            return dto;
        }

        /// <summary>
        /// Gets all shipments.
        /// </summary>
        /// <returns>A collections of all shipments in a ShipmentDTO format.</returns>
        public IEnumerable<ShipmentDTO> GetAll()
        {
            List<ShipmentDTO> shipments = new List<ShipmentDTO>();

            foreach (var shipment in this.context.Shipments.Include(c => c.Status))
            {
                var shipmentToDisplay = ShipmentMapper.DTOSelector.Compile().Invoke(shipment);
                shipments.Add(shipmentToDisplay);
            }
            return shipments;
        }

        /// <summary>
        /// Updates the specified Shipment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="shipment">The shipment.</param>
        /// <returns>The shipment in a ShipmentDTO format.</returns
        public ShipmentDTO Update(Guid id, ShipmentDTO shipment)
        {
            shipment.Status.ToLower();
            if (shipment.Status != "preparing" && shipment.Status != "on the way" && shipment.Status != "completed")
                throw new ArgumentException("The status is incorrect");

            var shipmentToUpdate = this.context.Shipments
                .Include(c => c.Status)
                .FirstOrDefault(s => s.Id == id)
                ?? throw new ArgumentNullException();

            if (shipmentToUpdate.Status.Name == "completed")
                throw new ArgumentException("A shipment that has a completed status can't be updated.");
            if (shipmentToUpdate.Status.Name == "on the way" && shipment.Status == "preparing")
                throw new ArgumentException("A shipment that is on the way can't be reverted to preparing.");
            if (shipmentToUpdate.Status.Name == "preparing" && shipment.Status == "completed")
                throw new ArgumentException("A shipment must first be on the way before being completed.");

            if (shipmentToUpdate.Status.Name != shipment.Status)
            {
                if (shipmentToUpdate.Status.Name == "preparing")
                    shipmentToUpdate.DepartureDate = DateTime.UtcNow;
                if (shipmentToUpdate.Status.Name == "on the way")
                    shipmentToUpdate.ArrivalDate = DateTime.UtcNow;
                shipmentToUpdate.Status.Name = shipment.Status;
                shipmentToUpdate.ModifiedOn = DateTime.UtcNow;
                this.context.SaveChanges();
            }

            var shipmentToDisplay = ShipmentMapper.DTOSelector.Compile().Invoke(shipmentToUpdate); 

            return shipmentToDisplay;
        }

        /// <summary>
        /// Creates a shipment.
        /// </summary>
        /// <param name="shipment">The shipment to be created.</param>
        /// <returns>The shipment to be created in a ShipmentDTO format.</returns>
        public ShipmentDTO Create(CreateShipmentDTO shipment)
        {
            var warehouse = this.context.Warehouses
                .FirstOrDefault(w => w.Id == shipment.WarehouseId);
            var status = this.context.Statuses
               .FirstOrDefault(w => w.Name == "preparing");

            var newShipment = new Shipment
            {
                Status = status,
                Warehouse = warehouse,
                CreatedOn = DateTime.UtcNow
            };
            this.context.Shipments.Add(newShipment);
            this.context.SaveChanges();

            var shipmentToDisplay = ShipmentMapper.DTOSelector.Compile().Invoke(newShipment);

            return shipmentToDisplay;
        }

        /// <summary>
        /// Deletes a shipment.
        /// </summary>
        /// <param name="id">The identifier of the shipment.</param>
        public bool Delete(Guid id)
        {
            var shipment = this.context.Shipments
                .FirstOrDefault(s => s.Id == id)
                ?? throw new ArgumentNullException();
            
            shipment.IsDeleted = true;
            shipment.DeletedOn = DateTime.UtcNow;
            this.context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Searches a shipment by a Warehouse Id.
        /// </summary>
        /// <param name="Id">The identifier of the warehouse.</param>
        /// <returns>A collection of all shipments by a given warehouse.</returns>
        public List<ShipmentDTO> SearchByWarehouse(Guid Id)
        {
            var warehouse = this.context.Warehouses
                .Include(w => w.Shipments)
                .FirstOrDefault(w => w.Id == Id);

            var shipments = this.context.Warehouses
                .Include(s => s.Shipments)
                .ThenInclude(s => s.Status)
                .Where(s => s.Id == warehouse.Id)
                .SelectMany(s => s.Shipments).ToList();
            var shipmentsToDisplay = new List<ShipmentDTO>();

            foreach (var shipment in shipments)
            {
                if (shipment.IsDeleted == true)
                    continue;

                var shipmentToDisplay = ShipmentMapper.DTOSelector.Compile().Invoke(shipment);
                shipmentsToDisplay.Add(shipmentToDisplay);
            }

            return shipmentsToDisplay;
        }

        /// <summary>
        /// Searches a shipment by customer.
        /// </summary>
        /// <param name="Id">The identifier of the customer.</param>
        /// <returns>A collection of all shipments of a given customer.</returns>
        public List<ShipmentDTO> SearchByCustomer(Guid Id)
        {
            var customer = this.context.Customers
                .FirstOrDefault(w => w.Id == Id);

            var shipments = this.context.Parcels
                .Where(s => s.CustomerId == customer.Id)
                .Select(s => s.ShipmentId).ToList();
            var shipmentsToDisplay = new List<ShipmentDTO>();

            foreach (var member in shipments)
            {
                var shipment = this.context.Shipments
                .Include(c => c.Status)
                .FirstOrDefault(s => s.Id == member)
                ?? throw new ArgumentNullException();

                var shipmentToDisplay= ShipmentMapper.DTOSelector.Compile().Invoke(shipment);
                shipmentsToDisplay.Add(shipmentToDisplay);
            }

            return shipmentsToDisplay;
        }
    }
}
