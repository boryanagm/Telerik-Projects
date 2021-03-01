using Agency.Models.Contracts;
using Agency.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models.Abstract
{
    public abstract class Vehicle : IVehicle
    {
        private VehicleType type;
        private double pricePerKilometer;
        private int passangerCapacity;

        protected Vehicle(int passangerCapacity, double pricePerKilometer)
        {
            this.PricePerKilometer = pricePerKilometer;
            this.PassangerCapacity = passangerCapacity;
        }

        public VehicleType Type 
        {
            get
            {
                return this.type;
            }
            protected set
            {
                this.type = value;
            }
        }

        public double PricePerKilometer 
        {
            get
            {
                return this.pricePerKilometer;
            }
            private set
            {
                if (value < 0.10 || value > 2.50)
                {
                    throw new ArgumentException("A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!");
                }
                this.pricePerKilometer = value;
            }
        }

        public virtual int PassangerCapacity 
        {
            get
            {
                return this.passangerCapacity;
            }
           protected set
            {
                if (!ValidateCapacity(value, 1, 800)) 
                {
                    throw new ArgumentException("A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");
                }
                this.passangerCapacity = value;
            }
        }

        public bool ValidateCapacity(int number, int minValue, int maxValue)
        {
            if (number < minValue || number > maxValue)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Passenger capacity: {this.PassangerCapacity}");
            sb.AppendLine($"Price per kilometer: {this.PricePerKilometer}".Trim());

            return sb.ToString().Trim();
        }
    }
}
