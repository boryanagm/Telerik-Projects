using Agency.Models.Abstract;
using Agency.Models.Contracts;
using Agency.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models
{
    public class Train : Vehicle, ITrain
    {
        private int carts;
        private int passangerCapacity;

        public Train(int passangerCapacity, double pricePerKilometer, int carts)
            : base(passangerCapacity, pricePerKilometer)
        {
            this.Carts = carts;
            // this.PassangerCapacity = passangerCapacity;
            this.Type = VehicleType.Land;
        }

        public int Carts
        {
            get
            {
                return this.carts;
            }
            private set
            {
                if (value < 1 || value > 15)
                {
                    throw new ArgumentException("A train cannot have less than 1 cart or more than 15 carts.");
                }
                this.carts = value;
            }
        }


        public override int PassangerCapacity
        {
            get
            {
                return this.passangerCapacity;
            }
            protected set
            {
                if (!ValidateCapacity(value, 30, 150))
                {
                    throw new ArgumentException("A train cannot have less than 30 passengers or more than 150 passengers.");
                }
                this.passangerCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string baseInfo = base.ToString();

            sb.AppendLine("Train ----");
            sb.AppendLine(baseInfo);
            sb.AppendLine($"Vehicle type: {VehicleType.Land}");
            sb.AppendLine($"Carts amount: {this.carts}".Trim());

            return sb.ToString().Trim();
        }
    }
}
