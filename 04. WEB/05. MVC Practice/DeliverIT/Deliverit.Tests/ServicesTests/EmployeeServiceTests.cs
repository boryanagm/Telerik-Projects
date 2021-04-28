using Deliverit.Services;
using DeliverIT.Database;
using DeliverIT.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deliverit.Tests.ServicesTests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        [TestMethod]
        public void Should_Return_Employee_If_AuthorizationEmail_IsCorrect()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Employee_If_AuthorizationEmail_IsCorrect));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Employees.AddRange(Utils.GetEmployees());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(assertContext);

                //Act
                var employeeEmail = "fer.trujillo@deliverit.com";
                var actualResult = sut.GetByEmployeeEmail(employeeEmail);

                //Assert
                var expectedResult = assertContext.Employees.FirstOrDefault(c => c.Email == employeeEmail);

                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void Should_Throw_Expception_When_Employee_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Throw_Expception_When_Employee_NotFound));

            //Act & Assert
            using (var context = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(context);

                Assert.ThrowsException<ArgumentNullException>(() => sut.GetByEmployeeEmail("isabelle.huppert@gmail.com"));
            }
        }

        [TestMethod]
        public void Should_Return_Admin_If_AuthorizationEmail_IsCorrect()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Return_Admin_If_AuthorizationEmail_IsCorrect));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Employees.AddRange(Utils.GetEmployees());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(assertContext);

                //Act
                var adminEmail = "admin@deliverit.com";
                var actualResult = sut.GetByEmployeeEmail(adminEmail);

                //Assert
                var expectedResult = assertContext.Employees.FirstOrDefault(c => c.Email == adminEmail);

                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void Should_Throw_Expception_When_Admin_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Throw_Expception_When_Admin_NotFound));

            //Act & Assert
            using (var context = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(context);

                Assert.ThrowsException<ArgumentNullException>(() => sut.GetByAdminEmail("isabelle.huppert@gmail.com"));
            }
        }

        [TestMethod]
        public void Get_By_Should_Return_Correct_Employee()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_By_Should_Return_Correct_Employee));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Employees.AddRange(Utils.GetEmployees());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(assertContext);

                //Act
                var actualResult = sut.Get(Guid.Parse("facdefb9-19df-42b3-9d3d-6524076e152f"));

                //Assert
                var expectedResult = assertContext.Employees
                    .FirstOrDefault(w => w.Id == Guid.Parse("facdefb9-19df-42b3-9d3d-6524076e152f"));

                Assert.AreEqual(expectedResult.Id, actualResult.Id);
                Assert.AreEqual(expectedResult.FirstName, actualResult.FirstName);
                Assert.AreEqual(expectedResult.LastName, actualResult.LastName);
                Assert.AreEqual(expectedResult.Email, actualResult.Email);
            }
        }

        [TestMethod]
        public void Throw_When_Employee_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_Employee_NotFound));

            //Act & Assert
            using (var context = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(context);

                Assert.ThrowsException<ArgumentNullException>(() => sut.Get(Guid.Parse("67258564-f023-4ed5-ab4b-8bf7971fee8c")));
            }
        }

        [TestMethod]
        public void Get_Should_Return_All_Employees()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_Should_Return_All_Employees));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Employees.AddRange(Utils.GetEmployees());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(assertContext);

                //Act
                var actualResult = sut.GetAll().ToList();
                int actualEmployeesCount = actualResult.Count();
                var firstEmployeeInActualList = actualResult.FirstOrDefault();
                var lastEmployeeInActualList = actualResult.Last();

                //Assert
                var expectedResult = assertContext.Employees.ToList();
                int expectedEmployeesCount = expectedResult.Count();
                var firstEmployeeInExpectedList = expectedResult.FirstOrDefault();
                var lastEmployeeInExpectedList = expectedResult.Last();

                Assert.AreEqual(expectedEmployeesCount, actualEmployeesCount);
                Assert.AreEqual(firstEmployeeInExpectedList.Id, firstEmployeeInActualList.Id);
                Assert.AreEqual(firstEmployeeInExpectedList.FirstName, firstEmployeeInActualList.FirstName);
                Assert.AreEqual(lastEmployeeInExpectedList.Id, lastEmployeeInActualList.Id);
                Assert.AreEqual(lastEmployeeInExpectedList.FirstName, lastEmployeeInActualList.FirstName);
            }
        }

        [TestMethod]
        public void Should_Create_New_Employee()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Create_New_Employee));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Employees.AddRange(Utils.GetEmployees());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(assertContext);

                //Act
                var employeeToCreate = new Employee()
                {
                    Id = Guid.Parse("71ec4e5f-17da-4e61-8903-bc71c026145b"),
                    FirstName = "Enrique",
                    LastName = "Pastor",
                    Email = "enriquete@deliverit.com",
                    AddressId = Guid.Parse("da703902-00bc-47da-b950-4fa730494d4e")
                };

                int employeesCount = assertContext.Employees.Count();
                var createdEmployee = sut.Create(employeeToCreate);

                //Assert
                int expectedEmployeesCount = employeesCount + 1;
                int actualEmployeesCount = assertContext.Employees.Count();

                Assert.AreEqual(expectedEmployeesCount, actualEmployeesCount);
            }
        }

        [TestMethod]
        public void Should_Update_AddressId_OfSelectedEmployee()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Update_AddressId_OfSelectedEmployee));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Employees.AddRange(Utils.GetEmployees());
                arrangeContext.Addresses.AddRange(Utils.GetAddresses());
                arrangeContext.Cities.AddRange(Utils.GetCities());
                arrangeContext.Countries.AddRange(Utils.GetCountries());

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(assertContext);

                //Act
                var employeeToUptadeId = Guid.Parse("facdefb9-19df-42b3-9d3d-6524076e152f");
                var newAddressId = Guid.Parse("5fd8c18f-6885-488e-af8c-ff06901a7d37");
                var actualResult = sut.Update(employeeToUptadeId, newAddressId);

                //Assert
                var expectedResult = assertContext.Employees
                    .FirstOrDefault(c => c.Id == employeeToUptadeId);

                Assert.AreEqual(expectedResult.Address.StreetName, actualResult.StreetName);
                Assert.AreEqual(expectedResult.Address.City.Name, actualResult.City);
                Assert.AreEqual(expectedResult.Address.City.Country.Name, actualResult.Country);
            }
        }

        [TestMethod]
        public void Should_Mark_True_IsDeleted_OfSelectedEmployee()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Should_Mark_True_IsDeleted_OfSelectedEmployee));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Employees.AddRange(Utils.GetEmployees());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new EmployeeService(assertContext);

                //Act
                var employeeToDeleteId = Guid.Parse("facdefb9-19df-42b3-9d3d-6524076e152f");
                var employeeToDelete = assertContext.Employees
                    .FirstOrDefault(c => c.Id == employeeToDeleteId);

                var actualResult = sut.Delete(employeeToDeleteId);
                var expectedResult = employeeToDelete.IsDeleted;

                //Assert
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

    }
}
