using System;
using System.Collections.Generic;
using Agency.Commands.Abstracts;
using Agency.Models.Contracts;

namespace Agency.Commands
{
    public class CreateBusCommand : Command
    {
        public CreateBusCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            int passengerCapacity;
            double pricePerKilometer;
            bool hasFreeTv;

            try
            {
                passengerCapacity = int.Parse(this.CommandParameters[0]);
                pricePerKilometer = double.Parse(this.CommandParameters[1]);
                hasFreeTv = bool.Parse(this.CommandParameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            IBus bus = this.Factory.CreateBus(passengerCapacity, pricePerKilometer, hasFreeTv);

            this.Database.Vehicles.Add((IVehicle)bus);

            return $"Vehicle with ID {this.Database.Vehicles.Count - 1} was created.";
        }
    }
}
