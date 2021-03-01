using Agency.Models.Abstract;
using Agency.Models.Contracts;
using Agency.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models
{
    public class Airplane : Vehicle, IAirplane
    {

        public Airplane(int passangerCapacity, double pricePerKilometer, bool isLowCost)
            : base(passangerCapacity, pricePerKilometer)
        {
            this.IsLowCost = isLowCost;
            this.Type = VehicleType.Air;
        }

        public bool IsLowCost { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string baseInfo = base.ToString();

            sb.AppendLine("Airplane ----");
            sb.AppendLine(baseInfo);
            sb.AppendLine($"Vehicle type: {VehicleType.Air}");
            sb.AppendLine($"Is low-cost: {this.IsLowCost}".Trim());

            return sb.ToString().Trim();
        }
    }
}
