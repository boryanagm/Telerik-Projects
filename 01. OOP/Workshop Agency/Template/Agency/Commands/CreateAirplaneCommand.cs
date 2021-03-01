using Agency.Commands.Abstracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateAirplaneCommand : Command
    {
        public CreateAirplaneCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            int passangerCapacity;
            double pricePerKilometer;
            bool isLowCost;

            try
            {
                passangerCapacity = int.Parse(this.CommandParameters[0]);
                pricePerKilometer = double.Parse(this.CommandParameters[1]);
                isLowCost = bool.Parse(this.CommandParameters[2]);
            }
            catch 
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            IAirplane airplane = this.Factory.CreateAirplane(passangerCapacity, pricePerKilometer, isLowCost);

            this.Database.Vehicles.Add((IVehicle)airplane);

            return $"Vehicle with ID {this.Database.Vehicles.Count - 1} was created.";
        }
    }
}
