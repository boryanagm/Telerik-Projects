using System;
using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Olympians;

namespace OlympicGames.Core.Factories
{
    public class OlympicsFactory : IOlympicsFactory
    {
        public IOlympian CreateBoxer(string firstName, string lastName, string country, string category, int wins, int losses)
        {
            Boxer boxer = new Boxer(firstName, lastName, country, category, wins, losses);

            return boxer;
        }

        public IOlympian CreateSprinter(string firstName, string lastName, string country, IDictionary<string, double> records)
        {
            Sprinter sprinter = new Sprinter(firstName, lastName, country, records);

            return sprinter;
        }
    }
}
