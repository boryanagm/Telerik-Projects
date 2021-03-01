using Agency.Commands.Abstracts;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class ListVehiclesCommand : Command
    {
        public ListVehiclesCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            return this.Database.Vehicles.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Vehicles).Trim()
                : "There are no registered vehicles.";
        }
    }
}
