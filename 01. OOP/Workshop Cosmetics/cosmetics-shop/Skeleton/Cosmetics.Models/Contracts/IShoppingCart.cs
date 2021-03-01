using System.Collections.Generic;

namespace Cosmetics.Contracts
{
    public interface IShoppingCart
    {

       // public List<IProduct> ProductList();


        public void AddProduct(IProduct product);


        public void RemoveProduct(IProduct product);


        public bool ContainsProduct(IProduct product);


        public decimal TotalPrice();
       
        // Which methods should be here?
        // Write them
    }
}