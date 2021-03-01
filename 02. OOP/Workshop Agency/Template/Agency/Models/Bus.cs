using Agency.Models.Abstract;
using Agency.Models.Contracts;
using Agency.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models
{
    public class Bus : Vehicle, IBus
    {
        private int passangerCapacity;

        public Bus(int passangerCapacity, double pricePerKilometer, bool hasFreeTv)
            : base(passangerCapacity, pricePerKilometer)
        {
            this.HasFreeTv = hasFreeTv;
            // this.PassangerCapacity = passangerCapacity;
            this.Type = VehicleType.Land;
        }

        public bool HasFreeTv { get; }


        public override int PassangerCapacity
        {
            get
            {
                return this.passangerCapacity;
            }
            protected set
            {
                if (!ValidateCapacity(value, 10, 50))
                {
                    throw new ArgumentException("A bus cannot have less than 10 passengers or more than 50 passengers.");
                }
                this.passangerCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string baseInfo = base.ToString();

            sb.AppendLine("Bus ----");
            sb.AppendLine(baseInfo);
            sb.AppendLine($"Vehicle type: {VehicleType.Land}");
            sb.AppendLine($"Has free TV: {this.HasFreeTv}".Trim());

            return sb.ToString().Trim();
        }
    }
}
