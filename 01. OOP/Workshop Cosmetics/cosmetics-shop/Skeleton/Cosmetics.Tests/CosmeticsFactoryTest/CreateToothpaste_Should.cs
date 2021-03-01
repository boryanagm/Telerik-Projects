using System.Collections.Generic;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Core.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cosmetics.UnitTests.CosmeticsFactoryTest
{
    [TestClass]
    public class CreateToothpaste_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeProduct()
        {
            // Arrange
            var factory = new CosmeticsFactory();

            // Act
            var product = factory.CreateToothpaste("name", "brand", 10, GenderType.Unisex, new List<string>());

            // Assert
            Assert.IsInstanceOfType(product, typeof(IProduct));
        }
    }
}
