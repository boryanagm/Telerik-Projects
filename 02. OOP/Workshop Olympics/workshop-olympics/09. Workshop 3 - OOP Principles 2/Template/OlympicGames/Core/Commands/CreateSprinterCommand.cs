using System;
using System.Collections.Generic;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : Command
    {
        public CreateSprinterCommand(IList<string> commandLine, IOlympicCommittee committee)
            : base(commandLine, committee)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 3)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            string firstName = this.CommandParameters[0];
            string lastName = this.CommandParameters[1];
            string country = this.CommandParameters[2];
          
            Dictionary<string, double> sprinterRecords = new Dictionary<string, double>();
           
            string range;
            double time;

            for (int i = 3; i < this.CommandParameters.Count; i++)
            {
                var records = this.CommandParameters[i].Split('/');

                range = records[0];
                time = double.Parse(records[1]);

                sprinterRecords[range] = time;
            }

            IOlympian olympian = this.Factory.CreateSprinter(firstName, lastName, country, sprinterRecords);

            Committee.Add(olympian);

            return olympian.CreateOlympian();
        }
    }
}
