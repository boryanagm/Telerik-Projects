using OlympicGames.Olympics.Abstract;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlympicGames.Olympics.Olympians
{
    public class Boxer : Olympian, IBoxer
    {
        private readonly BoxingCategory category;
        private int wins;
        private int losses;

        public Boxer(string firstName, string lastName, string country, string categoryAsString, int wins, int losses)
            : base(firstName, lastName, country)
        {
            categoryAsString = char.ToUpper(categoryAsString[0]) + categoryAsString.Substring(1);

            var categoryToEnum = Enum.TryParse(categoryAsString, out BoxingCategory categoryAsEnum); 

            this.category = categoryAsEnum;
            this.Wins = wins;
            this.Losses = losses;
        }

        public BoxingCategory Category => this.category; 

        public int Wins
        {
            get
            {
                return this.wins;
            }
            private set
            {
                if (!ValidateInteger(value))
                {
                    throw new ArgumentException("Wins must be between 0 and 100!");
                }

                this.wins = value;
            }
        }

        public int Losses
        {
            get
            {
                return this.losses;
            }
            private set
            {
                if (!ValidateInteger(value))
                {
                    throw new ArgumentException("Losses must be between 0 and 100!");
                }

                this.losses = value;
            }
        }

       
        public bool ValidateInteger(int number)
        {
            if (number < 0 || number > 100)
            {
                return false;
            }
            return true;
        }

        protected override string AdditionalInfo()
        {
            return $"Category: {this.category}\n" +
                $"Wins: {this.wins}\n" +
                $"Losses: {this.losses}\n";
        }
    }
}
