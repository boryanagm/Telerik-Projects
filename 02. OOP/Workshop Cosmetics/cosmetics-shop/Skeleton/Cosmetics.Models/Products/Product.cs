using System;
using System.Collections.Generic;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private readonly string name;
        private readonly string brand;
        private readonly decimal price;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            if (!ValidateNameLength(name))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (brand == null)
            {
                throw new ArgumentNullException();
            }
            if (!ValidateBrandLength(brand))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.name = name;
            this.brand = brand;
            this.price = price;
            this.gender = gender;
        }

        public virtual string Name => this.name;

        public virtual string Brand => this.brand;

        public decimal Price => this.price;

        public GenderType Gender => this.gender;

        public virtual bool ValidateNameLength(string name)
        {
            if (name.Length < 3 || name.Length > 10)
            {
                return false;
            }
            return true;
        }

        public virtual bool ValidateBrandLength(string brand)
        {
            if (brand.Length < 2 || brand.Length > 10)
            {
                return false;
            }
            return true;
        }

        public virtual string Print()
        {
            string info = $"#{this.Name} {this.Brand}\n #Price: ${this.Price}\n #Gender: " +
                    $"{this.Gender}";
            return info;
        }
    }
}
