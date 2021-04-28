using Deliverit.Services;
using DeliverIT.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Deliverit.Tests
{
    [TestClass]
    public class CountryServiceTests
    {
        [TestMethod]
        public void Get_By_Should_Return_Correct_Country()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_By_Should_Return_Correct_Country));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Countries.AddRange(Utils.GetCountries());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CountryService(assertContext);

                //Act
                var actualResult = sut.Get(Guid.Parse("2a84fe90-6605-4052-8a49-e7251af05754"));

                //Assert
                var expectedResult = assertContext.Countries.FirstOrDefault(c => c.Id == Guid.Parse("2a84fe90-6605-4052-8a49-e7251af05754"));
                Assert.AreEqual(expectedResult.Id, actualResult.Id);
                Assert.AreEqual(expectedResult.Name, actualResult.Name);
            }
        }

        [TestMethod]
        public void Throw_When_Country_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_Country_NotFound));

            //Act & Assert
            using (var context = new DeliveritDbContext(options))
            {
                var sut = new CountryService(context);

                Assert.ThrowsException<ArgumentNullException>(() => sut.Get(Guid.Parse("37637c27-cdc5-4f87-8854-9a6e5e43b8cd")));
            }
        }

        [TestMethod]
        public void Get_Should_Return_All_Countries()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Get_Should_Return_All_Countries));

            using (var arrangeContext = new DeliveritDbContext(options))
            {
                arrangeContext.Countries.AddRange(Utils.GetCountries());
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new DeliveritDbContext(options))
            {
                var sut = new CountryService(assertContext);

                //Act
                var actualResult = sut.GetAll().ToList();
                int actualCountriesCount = actualResult.Count();

                //Assert
                var expectedResult = assertContext.Countries.ToList();
                int expectedCitiesCount = expectedResult.Count();

                Assert.AreEqual(expectedCitiesCount, actualCountriesCount);
            }
        }
    }
}
