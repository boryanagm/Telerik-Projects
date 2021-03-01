using System;
using System.Collections.Generic;
using Agency.Commands.Abstracts;
using Agency.Models.Contracts;

namespace Agency.Commands
{
    public class CreateTrainCommand : Command
    {
        public CreateTrainCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }

        public override string Execute()
        {
            int passengerCapacity;
            double pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(this.CommandParameters[0]);
                pricePerKilometer = double.Parse(this.CommandParameters[1]);
                cartsCount = int.Parse(this.CommandParameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            ITrain train = this.Factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);

            this.Database.Vehicles.Add((IVehicle)train);

            return $"Vehicle with ID {this.Database.Vehicles.Count - 1} was created.";
        }
    }
}
