using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models
{
    public class Ticket : ITicket
    {

        public Ticket(IJourney journey, double administrativeCosts)
        {
            this.AdministrativeCosts = administrativeCosts;
            this.Journey = journey;
        }

        public double AdministrativeCosts { get; } // Validate?

        public IJourney Journey { get; }

        public double CalculatePrice()
        {
            double price = this.AdministrativeCosts + this.Journey.CalculatePrice();

            return price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Ticket ----");
            sb.AppendLine($"Destination: {this.Journey.Destination}");
            sb.AppendLine($"Price: {this.CalculatePrice()}".Trim());

            return sb.ToString().Trim();
        }
    }
}
