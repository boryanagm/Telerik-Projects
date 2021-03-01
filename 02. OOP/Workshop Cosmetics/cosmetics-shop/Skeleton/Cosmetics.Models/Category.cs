using Cosmetics.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Cosmetics
{
    public class Category : ICategory
    {
        private readonly string name;
        private readonly ICollection<IProduct> products;

        public Category(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            if (name.Length < 2 || name.Length > 15)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.name = name;
            this.products = new List<IProduct>();
        }

        public ICollection<IProduct> Products => new List<IProduct>(this.products);

        public string Name => this.name;

        public void AddProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            var productFound = this.products.FirstOrDefault(x => x.Name == product.Name);

            if (productFound == null)
            {
                throw new ArgumentNullException();
            }

            this.products.Remove(productFound);
        }

        public string Print()
        {
            if (!this.products.Any())
            {
                return $"#Category: {this.Name}\r\n #No product in this category";
            }

            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"#Category: {this.Name}");

            foreach (var product in this.products)
            {
                strBuilder.Append(product.Print());
            }

            return strBuilder.ToString();
        }
    }
}
