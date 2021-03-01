using System;
using System.Collections.Generic;
using Agency.Commands.Abstracts;

namespace Agency.Commands
{
    public class ListJourneysCommand : Command
    {
        public ListJourneysCommand(IList<string> commandParameters) 
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            return this.Database.Journeys.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Journeys).Trim()
                : "There are no registered journeys.";
        }
    }
}
