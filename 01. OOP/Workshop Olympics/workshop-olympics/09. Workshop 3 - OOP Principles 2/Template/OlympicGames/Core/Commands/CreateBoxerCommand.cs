using System;
using System.Collections.Generic;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Abstract;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Olympians;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : Command
    {
        public CreateBoxerCommand(IList<string> commandLine, IOlympicCommittee committee) 
            : base(commandLine, committee)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 6)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            string firstName = this.CommandParameters[0];
            string lastName = this.CommandParameters[1];
            string country = this.CommandParameters[2];
            string category = this.CommandParameters[3];

            int wins;
            int losses;

            bool isNumericWins = int.TryParse(this.CommandParameters[4], out wins);
            bool isNumericLosses = int.TryParse(this.CommandParameters[5], out losses);

            if (!isNumericWins || !isNumericLosses)
            {
                throw new ArgumentException("Wins and losses must be numbers!");
            }

            IOlympian olympian = this.Factory.CreateBoxer(firstName, lastName, country, category, wins, losses);

            Committee.Add(olympian);

            return olympian.CreateOlympian();
        }
    }
}
