using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products;
using System.Collections.Generic;


namespace Cosmetics.Core.Engine
{
    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            var category = new Category(name);
            return category;
        }

        public Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            var newShampoo = new Shampoo(name, brand, price, gender, milliliters, usage);
            return newShampoo;
        }

        public Toothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            var newToothpaste = new Toothpaste(name, brand, price, gender, string.Join(", ", ingredients));
            return newToothpaste;
        }

        public Cream CreateCream(string name, string brand, decimal price, GenderType gender, Scent scent)
        {
            var newCream = new Cream(name, brand, price, gender, scent);
            return newCream;
        }
        public ShoppingCart CreateShoppingCart()
        {
            var shoppingCart = new ShoppingCart();
            return shoppingCart;
        }
        
    }
}
