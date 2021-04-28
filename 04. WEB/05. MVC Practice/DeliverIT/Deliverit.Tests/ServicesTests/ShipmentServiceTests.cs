using Deliverit.Services;
using Deliverit.Services.Models;
using DeliverIT.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Deliverit.Tests
{
    [TestClass]
    public class ShipmentServiceTests
    {
        [TestMethod]
        public void Get_By_Should_Return_Correct_Shipment()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_By_Should_Return_Correct_Shipment));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.Shipments.AddRange(Utils.GetShipments());
                arrangeContext.Statuses.AddRange(Utils.GetStatuses());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new ShipmentService(assertContext);

                //Act
                var actualResult = sut.Get(Guid.Parse("ce465c59-4866-4905-bdbd-943a26f59fdd"));

                //Assert
                var expectedResult = assertContext.Shipments.FirstOrDefault(c => c.Id == Guid.Parse("ce465c59-4866-4905-bdbd-943a26f59fdd"));
                Assert.AreEqual(expectedResult.Id, actualResult.Id);
            }
        }

        [TestMethod]
        public void Throw_When_Shipment_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_Shipment_NotFound));

            //Act & Assert
            using (var context = new DeliveritDbContext(options))
            {
                var sut = new ShipmentService(context);

                Assert.ThrowsException<ArgumentNullException>(() => sut.Get(Guid.Parse("32637c27-cdc5-4f87-8854-9a6e5e43b8cd")));
            }
        }

        [TestMethod]
        public void Get_Should_Return_All_Shipments()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_Should_Return_All_Shipments));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new ShipmentService(assertContext);

                //Act
                var actualResult = sut.GetAll();
                int actualParcelCount = actualResult.Count();

                //Assert
                var expectedResult = assertContext.Shipments.Count();

                Assert.AreEqual(expectedResult, actualParcelCount);
            }
        }

        [TestMethod]
        public void Update_Should_Shipment()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Update_Should_Shipment));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.Shipments.AddRange(Utils.GetShipments());
                arrangeContext.Statuses.AddRange(Utils.GetStatuses());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new ShipmentService(assertContext);
                Guid shipmentId = new Guid("ce465c59-4866-4905-bdbd-943a26f59fdd");
                var shipmentToUpdate = new ShipmentDTO
                {
                    Status = "on the way"
                };

                //Act
                var assertResult = sut.Update(shipmentId, shipmentToUpdate);

                //Assert
                var actualShipment = assertContext.Shipments.FirstOrDefault(p => p.Id == shipmentId);
                Assert.AreEqual(actualShipment.Status.Name, shipmentToUpdate.Status);
            }
        }

        [TestMethod]
        public void Create_Should_Add_Shipment()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Create_Should_Add_Shipment));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.Shipments.AddRange(Utils.GetShipments());
                arrangeContext.Statuses.AddRange(Utils.GetStatuses());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new ShipmentService(assertContext);
                var shipmentCount = assertContext.Shipments.Count();
                Guid shipmentId = new Guid("ce465c59-4866-4905-bdbd-943a26f59fdd");
                var shipmentToCreate = new CreateShipmentDTO
                {
                    WarehouseId = new Guid("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba")
                };

                //Act
                var assertResult = sut.Create(shipmentToCreate);
                var expectedResult = shipmentCount + 1;

                //Assert
                var actualParcelCount = assertContext.Shipments.Count();
                Assert.AreEqual(expectedResult, actualParcelCount);
            }
        }

        [TestMethod]
        public void Delete_Should_Shipment()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Delete_Should_Shipment));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.Shipments.AddRange(Utils.GetShipments());
                arrangeContext.Statuses.AddRange(Utils.GetStatuses());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new ShipmentService(assertContext);

                Guid shipmentId = new Guid("ce465c59-4866-4905-bdbd-943a26f59fdd");

                //Act
                var assertResult = sut.Delete(shipmentId);

                //Assert
                var shipment = assertContext.Shipments
                .IgnoreQueryFilters()
                .FirstOrDefault(e => e.Id == shipmentId);

                Assert.AreEqual(shipment.IsDeleted, true);
            }
        }

        [TestMethod]
        public void Get_By_Customer()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_By_Customer));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new ShipmentService(assertContext);

                //Act
                Guid Id = new Guid("5adb06fe-fca4-4347-b1ea-118c55e17331");
                var expectedResult = sut.SearchByCustomer(Id);
                //Assert
                var customer = assertContext.Customers
                .FirstOrDefault(w => w.Id == Id);
                var actualResult = assertContext.Parcels.Where(s => s.CustomerId == customer.Id)
                .Select(s => s.ShipmentId).ToList();

                Assert.AreEqual(actualResult.Count, expectedResult.Count);
            }
        }

        [TestMethod]
        public void Search_By_Warehouse()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Search_By_Warehouse));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.Shipments.AddRange(Utils.GetShipments());
                arrangeContext.Statuses.AddRange(Utils.GetStatuses());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new ShipmentService(assertContext);

                //Act
                Guid Id = new Guid("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba");
                var expectedResult = sut.SearchByWarehouse(Id);
                //Assert
                var warehouse = assertContext.Warehouses
                .Include(w => w.Shipments)
                .FirstOrDefault(w => w.Id == Id);

                var actualResult = assertContext.Warehouses
                .Include(s => s.Shipments)
                .ThenInclude(s => s.Status)
                .Where(s => s.Id == warehouse.Id)
                .SelectMany(s => s.Shipments).ToList();

                Assert.AreEqual(actualResult.Count, expectedResult.Count);
            }
        }

    }

}

