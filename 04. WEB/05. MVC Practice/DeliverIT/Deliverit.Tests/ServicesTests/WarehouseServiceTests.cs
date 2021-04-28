using Deliverit.Services;
using DeliverIT.Database;
using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Deliverit.Tests.ServicesTests
{
    [TestClass]
    public class WarehouseServiceTests
    {
        [TestMethod]
        public void Get_By_Should_Return_Correct_Warehouse()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_By_Should_Return_Correct_Warehouse));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new WarehouseService(assertContext);

                //Act
                var actualResult = sut.Get(Guid.Parse("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba"));

                //Assert
                var expectedResult = assertContext.Warehouses
                    .Include(w => w.Address)
                       .ThenInclude(a => a.City)
                          .ThenInclude(c => c.Country)
                    .FirstOrDefault(w => w.Id == Guid.Parse("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba"));

                Assert.AreEqual(expectedResult.Id, actualResult.Id);
                Assert.AreEqual(expectedResult.Address.StreetName, actualResult.StreetName);
                Assert.AreEqual(expectedResult.Address.City.Name, actualResult.City);
                Assert.AreEqual(expectedResult.Address.City.Country.Name, actualResult.Country);
            }
        }

        [TestMethod]
        public void Throw_When_Warehouse_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_Warehouse_NotFound));

            //Act & Assert
            using (var context = new DeliveritDbContext(options))
            {
                var sut = new WarehouseService(context);

                Assert.ThrowsException<ArgumentNullException>(() => sut.Get(Guid.Parse("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba")));
            }
        }

        [TestMethod]
        public void Get_Should_Return_All_Warehouses()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_Should_Return_All_Warehouses));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new WarehouseService(assertContext);

                //Act
                var actualResult = sut.GetAll().ToList();
                int actualWarehousesCount = actualResult.Count();
                var firstWarehouseInActualList = actualResult.FirstOrDefault();
                var lastWarehouseInActualList = actualResult.LastOrDefault();

                //Assert
                var expectedResult = assertContext.Warehouses.ToList();
                int expectedWarehousesCount = expectedResult.Count();
                var firstWarehouseInExpectedList = expectedResult.FirstOrDefault();
                var lastWarehouseInExpectedList = expectedResult.LastOrDefault();

                Assert.AreEqual(expectedWarehousesCount, actualWarehousesCount);
                Assert.AreEqual(firstWarehouseInExpectedList.Id, firstWarehouseInActualList.Id);
                Assert.AreEqual(firstWarehouseInExpectedList.Address.StreetName, firstWarehouseInActualList.StreetName);
                Assert.AreEqual(lastWarehouseInExpectedList.Id, lastWarehouseInActualList.Id);
                Assert.AreEqual(lastWarehouseInExpectedList.Address.StreetName, lastWarehouseInActualList.StreetName);
            }
        }

        [TestMethod]
        public void Should_Create_New_Warehouse()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Create_New_Warehouse));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new WarehouseService(assertContext);

                //Act
                var warehouseToCreate = new Warehouse()
                {
                    Id = Guid.Parse("519f6bc2-5a4c-4ad1-9f79-6b4ad0a65288"),
                    AddressId = Guid.Parse("36049406-10ba-499d-916b-063422046239")
                };

                int warehousesCount = assertContext.Warehouses.Count();
                var createdWarehouse = sut.Create(warehouseToCreate);

                //Assert
                int expectedWarehousesCount = warehousesCount + 1;
                int actualWarehousesCount = assertContext.Warehouses.Count();

                Assert.AreEqual(expectedWarehousesCount, actualWarehousesCount);
            }
        }

        [TestMethod]
        public void Should_Update_AddressId_OfSelectedWarehouse()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Update_AddressId_OfSelectedWarehouse));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new WarehouseService(assertContext);

                //Act
                var warehouseToUptadeId = Guid.Parse("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba");
                var newAddressId = Guid.Parse("ac2fee3a-f76e-4d94-aa42-d85b4bb45299");
                var actualResult = sut.Update(warehouseToUptadeId, newAddressId);

                //Assert
                var expectedResult = assertContext.Warehouses
                    .FirstOrDefault(w => w.Id == Guid.Parse("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba"));

                Assert.AreEqual(expectedResult.Address.StreetName, actualResult.StreetName);
                Assert.AreEqual(expectedResult.Address.City.Name, actualResult.City);
                Assert.AreEqual(expectedResult.Address.City.Country.Name, actualResult.Country);
            }
        }

        [TestMethod]
        public void Should_Mark_True_IsDeleted_OfSelectedWarehouse()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Mark_True_IsDeleted_OfSelectedWarehouse));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Warehouses.AddRange(Utils.GetWarehouses());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new WarehouseService(assertContext);

                //Act
                var warehouseToDeleteId = Guid.Parse("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba");
                var warehouseToDelete = assertContext.Warehouses
                    .FirstOrDefault(w => w.Id == warehouseToDeleteId);

                var actualResult = sut.Delete(warehouseToDeleteId);
                var expectedResult = warehouseToDelete.IsDeleted;

                //Assert
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
