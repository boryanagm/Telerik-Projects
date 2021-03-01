using Agency.Commands;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agency.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];
            List<string> commandParameters = lineParameters.Skip(1).ToList();

            return commandName switch
            {
                "createairplane" => new CreateAirplaneCommand(commandParameters),
                "createbus" => new CreateBusCommand(commandParameters),
                "createtrain" => new CreateTrainCommand(commandParameters),
                "createticket" => new CreateTicketCommand(commandParameters),
                "createjourney" => new CreateJourneyCommand(commandParameters),
                "listjourneys" => new ListJourneysCommand(commandParameters),
                "listtickets" => new ListTicketsCommand(commandParameters),
                "listvehicles" => new ListVehiclesCommand(commandParameters),
                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
