using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Core.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cosmetics.UnitTests.CosmeticsFactoryTest
{
    [TestClass]
    public class CreateShampoo_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeProduct()
        {
            // Arrange, Act, Assert
            var factory = new CosmeticsFactory();

            // Act
            var product = factory.CreateShampoo("name", "brand", 10, GenderType.Unisex, 10, UsageType.EveryDay);

            // Assert
            Assert.IsInstanceOfType(product, typeof(IProduct));
        }
    }
}
