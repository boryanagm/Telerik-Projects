using System;
using System.Collections.Generic;
using Agency.Commands.Abstracts;
using Agency.Models.Contracts;

namespace Agency.Commands
{
    public class CreateJourneyCommand : Command
    {
        public CreateJourneyCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = this.CommandParameters[0];
                destination = this.CommandParameters[1];
                distance = int.Parse(this.CommandParameters[2]);
                
                int vehicleId = int.Parse(this.CommandParameters[3]);
                vehicle = this.Database.Vehicles[vehicleId];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }

            var journey = this.Factory.CreateJourney(startLocation, destination, distance, vehicle);
            this.Database.Journeys.Add(journey);

            return $"Journey with ID {this.Database.Journeys.Count - 1} was created.";
        }
    }
}
