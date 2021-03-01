using System.Collections.Generic;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using System;
using OlympicGames.Core.Providers;
using OlympicGames.Olympics.Contracts;
using System.Linq;
using System.Text;
using OlympicGames.Olympics.Enums;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand : Command
    {
        public ListOlympiansCommand(IList<string> commandLine, IOlympicCommittee committee)
            : base(commandLine, committee)
        {
        }

        public override string Execute()
        {
            if (Committee.Olympians.Count == 0)
            {
                return  "NO OLYMPIANS ADDED";
            }

            if (this.CommandParameters.Count > 2)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            string key = "firstname";
            string order = "asc";

            if (this.CommandParameters.Count == 1)
            {
                key = this.CommandParameters[0];
            }
            else if (this.CommandParameters.Count == 2)
            {
                key = this.CommandParameters[0];
                order = this.CommandParameters[1];
            }

            List<IOlympian> sorted = Committee.Olympians.ToList();

            if (order == "asc")
            {
                switch (key)
                {
                    case "firstname":

                        sorted = Committee.Olympians.OrderBy(x => x.FirstName).ToList();

                        break;

                    case "lastname":

                        sorted = Committee.Olympians.OrderBy(x => x.LastName).ToList();

                        break;

                    case "country":

                        sorted = Committee.Olympians.OrderBy(x => x.Country).ToList();

                        break;
                }
            }
            else
            {
                switch (key)
                {
                    case "firstname":

                        sorted = Committee.Olympians.OrderByDescending(x => x.FirstName).ToList();

                        break;

                    case "lastname":

                        sorted = Committee.Olympians.OrderByDescending(x => x.LastName).ToList();

                        break;

                    case "country":

                        sorted = Committee.Olympians.OrderByDescending(x => x.Country).ToList();

                        break;
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Sorted by [key: {key}] in [order: {order}]".Trim());

            foreach (var olympian in sorted)
            {
                sb.AppendLine(olympian.ListOlympians()); 
            }

            return sb.ToString().Trim();
        }
    }
}
