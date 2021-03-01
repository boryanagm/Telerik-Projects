using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models
{
    public class Journey : IJourney
    {

        private string startLocation;
        private string destination;
        private int distance;

        public Journey(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            this.StartLocation = startLocation;
            this.Destination = destination;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string StartLocation 
        {
            get
            {
                return this.startLocation;
            }
            private set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentException("The length of StartLocation must be between 5 and 25 symbols.");
                }
                this.startLocation = value;
            }
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            private set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentException("The length of Destination must be between 5 and 25 symbols.");
                }
                this.destination = value;
            }
        }

        public int Distance 
        {
            get
            {
                return this.distance;
            }
            private set
            {
                if (value < 5 || value > 5000)
                {
                    throw new ArgumentException("Distance must be between 5 and 5000 kilometers.");
                }
                this.distance = value;
            }
        }

        public IVehicle Vehicle { get; } 

        public bool ValidateString(string str)
        {
            if (str.Length < 5 || str.Length > 25)
            {
                return false;
            }
            return true;
        }

        public double CalculatePrice()
        {
            double price = this.Distance * this.Vehicle.PricePerKilometer;

            return price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Journey ----");
            sb.AppendLine($"Start location: {this.startLocation}");
            sb.AppendLine($"Destination: {this.destination}");
            sb.AppendLine($"Distance: {this.distance}");
            sb.AppendLine($"Vehicle type: {this.Vehicle.Type}");
            sb.AppendLine($"Travel costs: {this.CalculatePrice()}".Trim());

            return sb.ToString().Trim();
        }
    }
}
