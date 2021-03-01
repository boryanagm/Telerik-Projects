using System.Collections.Generic;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected Command(IList<string> commandLine, IOlympicCommittee committee)
        {
            this.Committee = committee;
            this.Factory = new OlympicsFactory();
            this.CommandParameters = new List<string>(commandLine);
        }

        protected IList<string> CommandParameters { get; }

        protected IOlympicCommittee Committee { get; }

        protected IOlympicsFactory Factory { get; }

        public abstract string Execute();
    }
}
