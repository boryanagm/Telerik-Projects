using Cosmetics.Common;
using Cosmetics.Contracts;
using System;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private readonly uint milliliters;
        private readonly UsageType usageType;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usageType)
            :base(name, brand, price, gender)
        {
            if (milliliters < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.milliliters = milliliters;
            this.usageType = usageType;
        }

        public uint Milliliters => this.milliliters;
        public UsageType UsageType => this.usageType;
       

        public override string Print()
        {
            string info = base.Print() + $"\n #Milliliters: {this.Milliliters}\n #Usage: {this.UsageType}\n ===";
            return info;
        }
    }
}
