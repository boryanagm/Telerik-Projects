using System;
using System.Collections.Generic;
using Agency.Commands.Abstracts;

namespace Agency.Commands
{
    public class ListTicketsCommand : Command
    {
        public ListTicketsCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            return this.Database.Tickets.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Tickets).Trim()
                : "There are no registered tickets.";
        }
    }
}
