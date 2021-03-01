using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private readonly string  ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
           : base(name, brand, price, gender)
        {
            this.ingredients = ingredients ?? throw new ArgumentNullException();           
        }

        public string Ingredients => this.ingredients;

        public override string Print()
        {
            string info = base.Print() + $"\n #Ingredients: {this.Ingredients}\n ===";
            return info;
        }
    }
}