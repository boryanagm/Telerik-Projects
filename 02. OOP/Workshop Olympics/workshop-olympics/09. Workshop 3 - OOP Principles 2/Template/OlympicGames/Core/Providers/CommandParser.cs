using System;
using System.Linq;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        // Every command gets the same instance of OlympicCommittee
        private static readonly IOlympicCommittee olympicCommittee = new OlympicCommittee();

        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0];
            var parameters = lineParameters.Skip(1).ToList();

            return commandName switch
            {
                "createboxer" => new CreateBoxerCommand(parameters, olympicCommittee),
                "createsprinter" => new CreateSprinterCommand(parameters, olympicCommittee),
                "listolympians" => new ListOlympiansCommand(parameters, olympicCommittee),

                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
