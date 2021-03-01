using OlympicGames.Olympics.Abstract;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlympicGames.Olympics.Olympians
{
    class Sprinter : Olympian, ISprinter
    {
        private readonly IDictionary<string, double> personalRecords;

        public Sprinter(string firstName, string lastName, string country, IDictionary<string, double> personalRecords)
            : base(firstName, lastName, country)
        {
            this.personalRecords = personalRecords; // Or this.PersonalRecords????
        }

        public IDictionary<string, double> PersonalRecords => this.personalRecords;

        public string PrintRecords(IDictionary<string, double> personalRecords)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this.personalRecords)
            {
                sb.AppendLine($"{kvp.Key}m: {kvp.Value}s");
            }

            return sb.ToString();
        }

        protected override string AdditionalInfo()
        {
            if (personalRecords.Count == 0)
            {
                return "NO PERSONAL RECORDS SET";
            }
            return $"PERSONAL RECORDS:\n{PrintRecords(this.personalRecords)}";
        }
    }
}
