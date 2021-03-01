using System;
using System.Collections.Generic;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Cream : Product, ICream
    {
        private readonly Scent scent;

        public Cream(string name, string brand, decimal price, GenderType gender, Scent scent)
           : base(name, brand, price, gender)
        {
            this.scent = scent;
        }

        public Scent Scent => this.scent;

        public override bool ValidateNameLength(string name)
        {
            if (name.Length < 3 || name.Length > 15)
            {
                return false;
            }
            return true;
        }

        public override bool ValidateBrandLength(string brand)
        {
            if (brand.Length < 3 || brand.Length > 15)
            {
                return false;
            }
            return true;
        }

        public override string Print()
        {
            string info = base.Print() + $"\n #Scent: {this.Scent}\n ===";
            return info;
        }
    }
}
