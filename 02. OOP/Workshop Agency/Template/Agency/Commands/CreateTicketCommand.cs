using Agency.Commands.Abstracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateTicketCommand : Command
    {
        public CreateTicketCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            IJourney journey;
            double administrativeCosts;

            try
            {
                int journeyId = int.Parse(this.CommandParameters[0]);
                administrativeCosts = double.Parse(this.CommandParameters[1]);

                journey = this.Database.Journeys[journeyId];
            }
            catch 
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this.Factory.CreateTicket(journey, administrativeCosts);
            this.Database.Tickets.Add(ticket);

            return $"Ticket with ID {this.Database.Tickets.Count - 1} was created.";
        }
    }
}
