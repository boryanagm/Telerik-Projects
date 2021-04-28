using Deliverit.Services;
using DeliverIT.Database;
using DeliverIT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deliverit.Tests.ServicesTests
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void Should_Return_Customer_If_AuthorizationEmail_IsCorrect()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Customer_If_AuthorizationEmail_IsCorrect));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var customerEmail = "isabelle.huppert@gmail.com";
                var actualResult = sut.GetByCustomerEmail(customerEmail);

                //Assert
                var expectedResult = assertContext.Customers.FirstOrDefault(c => c.Email == customerEmail);

                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void Should_Throw_Expception_When_Customer_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Throw_Expception_When_Customer_NotFound));

            //Act & Assert
            using (var context = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(context);

                Assert.ThrowsException<ArgumentNullException>(() => sut.GetByCustomerEmail("notfound@abv.bg"));
            }
        }

        [TestMethod]
        public void Get_By_Should_Return_Correct_Customer()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_By_Should_Return_Correct_Customer));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var actualResult = sut.Get(Guid.Parse("c803ff6d-efb9-401a-81d8-7e9df0fcd4c1"));

                //Assert
                var expectedResult = assertContext.Customers
                    .Include(c => c.Address)
                       .ThenInclude(a => a.City)
                          .ThenInclude(c => c.Country)
                    .FirstOrDefault(w => w.Id == Guid.Parse("c803ff6d-efb9-401a-81d8-7e9df0fcd4c1"));

                Assert.AreEqual(expectedResult.Id, actualResult.Id);
                Assert.AreEqual(expectedResult.FirstName, actualResult.FirstName);
                Assert.AreEqual(expectedResult.LastName, actualResult.LastName);
                Assert.AreEqual(expectedResult.Email, actualResult.Email);
                Assert.AreEqual(expectedResult.Address.StreetName, actualResult.StreetName);
                Assert.AreEqual(expectedResult.Address.City.Name, actualResult.City);
                Assert.AreEqual(expectedResult.Address.City.Country.Name, actualResult.Country);
            }
        }

        [TestMethod]
        public void Throw_When_Customer_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_Customer_NotFound));

            //Act & Assert
            using (var context = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(context);

                Assert.ThrowsException<ArgumentNullException>(() => sut.Get(Guid.Parse("e6d2c0f7-cffb-4155-8a13-5976136cd4db")));
            }
        }

        [TestMethod]
        public void Get_Should_Return_All_Customers()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_Should_Return_All_Customers));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var actualResult = sut.GetAll().ToList();
                int actualCustomersCount = actualResult.Count();
                var firstCustomerInActualList = actualResult.FirstOrDefault();
                var lastCustomerInActualList = actualResult.LastOrDefault();

                //Assert
                var expectedResult = assertContext.Customers.ToList();
                int expectedCustomersCount = expectedResult.Count();
                var firstCustomerInExpectedList = expectedResult.FirstOrDefault();
                var lastCustomerInExpectedList = expectedResult.LastOrDefault();

                Assert.AreEqual(expectedCustomersCount, actualCustomersCount);
                Assert.AreEqual(firstCustomerInExpectedList.Id, firstCustomerInActualList.Id);
                Assert.AreEqual(firstCustomerInExpectedList.FirstName, firstCustomerInActualList.FirstName);
                Assert.AreEqual(lastCustomerInExpectedList.Id, lastCustomerInActualList.Id);
                Assert.AreEqual(lastCustomerInExpectedList.FirstName, lastCustomerInActualList.FirstName);
            }
        }

        [TestMethod]
        public void Should_Return_CustomersCount()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_CustomersCount));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var actualResult = sut.GetCount();

                //Assert
                var expectedResult = assertContext.Customers.Count();

                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void Should_Create_New_Customer()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Create_New_Customer));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var customerToCreate = new Customer()
                {
                    Id = Guid.Parse("ed15cc44-60a9-476d-9ad7-f694a6eb1aef"),
                    FirstName = "Enrique",
                    LastName = "Pastor",
                    Email = "enriquete@gmail.com",
                    AddressId = Guid.Parse("da703902-00bc-47da-b950-4fa730494d4e")
                };

                int customersCount = assertContext.Customers.Count();
                var createdCustomer = sut.Create(customerToCreate);

                //Assert
                int expectedCustomersCount = customersCount + 1;
                int actualCustomersCount = assertContext.Customers.Count();

                Assert.AreEqual(expectedCustomersCount, actualCustomersCount);
            }
        }

        [TestMethod]
        public void Should_Update_AddressId_OfSelectedCustomer()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Update_AddressId_OfSelectedCustomer));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var customerToUptadeId = Guid.Parse("5adb06fe-fca4-4347-b1ea-118c55e17331");
                var newAddressId = Guid.Parse("b1347388-583d-4324-870a-e487e61ef483");
                var actualResult = sut.Update(customerToUptadeId, newAddressId);

                //Assert
                var expectedResult = assertContext.Customers
                    .FirstOrDefault(c => c.Id == customerToUptadeId);

                Assert.AreEqual(expectedResult.Address.StreetName, actualResult.StreetName);
                Assert.AreEqual(expectedResult.Address.City.Name, actualResult.City);
                Assert.AreEqual(expectedResult.Address.City.Country.Name, actualResult.Country);
            }
        }

        [TestMethod]
        public void Should_Mark_True_IsDeleted_OfSelectedCustomer()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Mark_True_IsDeleted_OfSelectedCustomer));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var customerToDeleteId = Guid.Parse("5adb06fe-fca4-4347-b1ea-118c55e17331");
                var customerToDelete = assertContext.Customers
                    .FirstOrDefault(c => c.Id == customerToDeleteId);

                var actualResult = sut.Delete(customerToDeleteId);
                var expectedResult = customerToDelete.IsDeleted;

                //Assert
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void Should_Return_Customer_When_MultipleCriteria_SearchByFirstName_IsApplied()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Customer_When_MultipleCriteria_SearchByFirstName_IsApplied));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);
                var firstNameSearch = "Isabelle";
                var customerFilter = new CustomerFilter
                {
                    FirstName = firstNameSearch,
                    LastName = "x",
                    Email = "x"
                };
                //Act
                var actualResult = sut.GetByMultipleCriteria(customerFilter);             

                //Assert
                var expectedResult = assertContext.Customers.Where(c => c.FirstName == firstNameSearch).ToList();

                Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            }
        }

        [TestMethod]
        public void Should_Return_Customer_When_MultipleCriteria_SearchByLastName_IsApplied()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Customer_When_MultipleCriteria_SearchByLastName_IsApplied));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);
                var lastNameSearch = "Petrauskas";
                var customerFilter = new CustomerFilter
                {
                    FirstName = "x",
                    LastName = lastNameSearch,
                    Email = "x"
                };
                //Act
                var actualResult = sut.GetByMultipleCriteria(customerFilter);

                //Assert
                var expectedResult = assertContext.Customers.Where(c => c.LastName == lastNameSearch).ToList();

                Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            }
        }

        [TestMethod]
        public void Should_Return_Customer_When_MultipleCriteria_SearchByEmail_IsApplied()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Customer_When_MultipleCriteria_SearchByEmail_IsApplied));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);
                var emailSearch = "isa";
                var customerFilter = new CustomerFilter
                {
                    FirstName = "x",
                    LastName = "x",
                    Email = emailSearch
                };
                //Act
                var actualResult = sut.GetByMultipleCriteria(customerFilter);

                //Assert
                var expectedResult = assertContext.Customers.Where(c => c.Email.Contains(emailSearch)).ToList();

                Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            }
        }

        [TestMethod]
        public void Should_Return_Incoming_Parcels()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Incoming_Parcels));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Parcels.AddRange(Utils.GetParcels());
                arrangeContext.Shipments.AddRange(Utils.GetShipments());
                arrangeContext.Statuses.AddRange(Utils.GetStatuses());
                arrangeContext.Categories.AddRange(Utils.GetCategories());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var customerId = Guid.Parse("5adb06fe-fca4-4347-b1ea-118c55e17331");
                var actualResult = sut.GetIncomingParcels(customerId);
                int actualParcelsCount = actualResult.Count();
                var firstParcelInActualList = actualResult.FirstOrDefault();
                var lastParcelInActualList = actualResult.LastOrDefault();

                //Assert
                var expectedResult = assertContext.Customers
                   .FirstOrDefault(c => c.Id == customerId).Parcels
                   .Where(p => p.Shipment.Status.Name == "on the way" || p.Shipment.Status.Name == "preparing")
                   .ToList();

                int expectedParcelsCount = expectedResult.Count();
                var firstParcelInExpectedList = expectedResult.FirstOrDefault();
                var lastParcelInExpectedList = expectedResult.LastOrDefault();

                Assert.AreEqual(expectedParcelsCount, actualParcelsCount);
                Assert.AreEqual(firstParcelInExpectedList.Id, firstParcelInActualList.Id);
                Assert.AreEqual(lastParcelInExpectedList.Id, lastParcelInActualList.Id);
            }
        }

        [TestMethod]
        public void Should_Return_Past_Parcels()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Past_Parcels));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Parcels.AddRange(Utils.GetParcels());
                arrangeContext.Shipments.AddRange(Utils.GetShipments());
                arrangeContext.Statuses.AddRange(Utils.GetStatuses());
                arrangeContext.Categories.AddRange(Utils.GetCategories());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var customerId = Guid.Parse("c803ff6d-efb9-401a-81d8-7e9df0fcd4c1");
                var actualResult = sut.GetPastParcels(customerId);
                int actualParcelsCount = actualResult.Count();
                var firstParcelInActualList = actualResult.FirstOrDefault();
                var lastParcelInActualList = actualResult.LastOrDefault();

                //Assert
                var expectedResult = assertContext.Customers
                   .FirstOrDefault(c => c.Id == customerId).Parcels
                   .Where(p => p.Shipment.Status.Name == "completed" || p.Shipment.Status.Name == "canceled")
                   .ToList();

                int expectedParcelsCount = expectedResult.Count();
                var firstParcelInExpectedList = expectedResult.FirstOrDefault();
                var lastParcelInExpectedList = expectedResult.LastOrDefault();

                Assert.AreEqual(expectedParcelsCount, actualParcelsCount);
                Assert.AreEqual(firstParcelInExpectedList.Id, firstParcelInActualList.Id);
                Assert.AreEqual(lastParcelInExpectedList.Id, lastParcelInActualList.Id);
            }
        }

        [TestMethod]
        public void Should_Return_Customer_When_SearchByKeyWord_IsApplied()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Customer_When_SearchByKeyWord_IsApplied));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Customers.AddRange(Utils.GetCustomers());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CustomerService(assertContext);

                //Act
                var keyWord = "Petrauskas";
                var actualResult = sut.GetByKeyWord(keyWord);

                //Assert
                var expectedResult = assertContext.Customers
                    .FirstOrDefault(c => c.FirstName == keyWord
                    || c.LastName == keyWord
                    || c.Email == keyWord);

                Assert.AreEqual(expectedResult.Email, actualResult.Email);
            }
        }
    }
}
