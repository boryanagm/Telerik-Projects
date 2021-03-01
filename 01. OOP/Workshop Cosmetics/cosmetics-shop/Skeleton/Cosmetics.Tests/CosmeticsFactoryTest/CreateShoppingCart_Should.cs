using Cosmetics.Contracts;
using Cosmetics.Core.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cosmetics.UnitTests.CosmeticsFactoryTest
{
    [TestClass]
    public class CreateShoppingCart_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeShoppingCart()
        {
            // Arrange, Act, Assert
            var factory = new CosmeticsFactory();

            // Act
            var cart = factory.CreateShoppingCart();

            // Assert
            Assert.IsInstanceOfType(cart, typeof(IShoppingCart));
        }
    }
}
